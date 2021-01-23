    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace Wpf_21642381
    {
        #region MainWindow
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += MainWindow_Loaded;
            }
    
            // testing
            async void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
    
                try
                {
                    Func<Task> doAsync = async () =>
                    {
                        await Task.Delay(4000);
                    };
    
                    var task = doAsync();
                    var handle = ((IAsyncResult)task).AsyncWaitHandle;
    
                    var startTick = Environment.TickCount;
                    handle.WaitOneAndPump(5000);
                    MessageBox.Show("Lapse: " + (Environment.TickCount - startTick));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    
        #region WaitExt
        // WaitOneAndPump
        public static class WaitExt
        {
            public static bool WaitOneAndPump(this WaitHandle handle, int millisecondsTimeout)
            {
                using (var operationPendingMre = new ManualResetEvent(false))
                {
                    var result = false;
    
                    var startTick = Environment.TickCount;
    
                    var dispatcher = Dispatcher.CurrentDispatcher;
    
                    var frame = new DispatcherFrame();
    
                    var handles = new[] { 
                            handle.SafeWaitHandle.DangerousGetHandle(), 
                            operationPendingMre.SafeWaitHandle.DangerousGetHandle() };
    
                    Action idleAction = () => operationPendingMre.Set();
    
                    DispatcherOperation idleOperation = null;
    
                    Func<uint> getTimeout;
                    if (Timeout.Infinite == millisecondsTimeout)
                        getTimeout = () => INFINITE;
                    else
                        getTimeout = () => (uint)Math.Max(0, millisecondsTimeout + startTick - Environment.TickCount);
    
                    DispatcherHookEventHandler onOperationPosted = (s, e) =>
                    {
                        // this may occur on a random thread,
                        // trigger a helper event and 
                        // unblock MsgWaitForMultipleObjectsEx inside onDispatcherInactive
                        operationPendingMre.Set();
                    };
    
                    DispatcherHookEventHandler onOperationCompleted = (s, e) =>
                    {
                        // this should be fired on the Dispather thread
                        Debug.Assert(Thread.CurrentThread == dispatcher.Thread);
    
                        // do an instant handle check
                        var nativeResult = WaitForSingleObject(handles[0], 0);
                        if (nativeResult == WAIT_OBJECT_0)
                            result = true;
                        else if (nativeResult == WAIT_ABANDONED_0)
                            throw new AbandonedMutexException(-1, handle);
                        else if (getTimeout() == 0)
                            result = false;
                        else if (nativeResult == WAIT_TIMEOUT)
                            return;
                        else
                            throw new InvalidOperationException("WaitForSingleObject");
    
                        // end the nested Dispatcher loop
                        frame.Continue = false;
                    };
    
                    EventHandler onDispatcherInactive = (s, e) =>
                    {
                        operationPendingMre.Reset();
    
                        // wait for the handle or a message
                        var timeout = getTimeout();
    
                        var nativeResult = MsgWaitForMultipleObjectsEx(
                             (uint)handles.Length, handles,
                             timeout,
                             QS_EVENTMASK,
                             MWMO_INPUTAVAILABLE);
    
                        if (nativeResult == WAIT_OBJECT_0)
                            // handle signalled
                            result = true; 
                        else if (nativeResult == WAIT_TIMEOUT)
                            // timed out
                            result = false; 
                        else if (nativeResult == WAIT_ABANDONED_0)
                            // abandonded mutex
                            throw new AbandonedMutexException(-1, handle);
                        else if (nativeResult == WAIT_OBJECT_0 + 1)
                            // operation posted from another thread, yield to the frame loop
                            return;
                        else if (nativeResult == WAIT_OBJECT_0 + 2) 
                        {
                            // a Windows message 
                            if (getTimeout() > 0)
                            {
                                // message pending, yield to the frame loop
                                idleOperation.Abort();
                                idleOperation = dispatcher.BeginInvoke(idleAction, DispatcherPriority.ApplicationIdle);
                                return; 
                            }
    
                            // timed out
                            result = false;
                        }
                        else 
                            // unknown result
                            throw new InvalidOperationException("MsgWaitForMultipleObjectsEx");
    
                        // end the nested Dispatcher loop
                        frame.Continue = false;
                    };
    
                    dispatcher.Hooks.OperationCompleted += onOperationCompleted;
                    dispatcher.Hooks.OperationPosted += onOperationPosted;
                    dispatcher.Hooks.DispatcherInactive += onDispatcherInactive;
    
                    idleOperation = dispatcher.BeginInvoke(idleAction, DispatcherPriority.ApplicationIdle);
                    try
                    {
                        // onDispatcherInactive will be called on the new frame,
                        // as soon as Dispatcher becomes idle
                        Dispatcher.PushFrame(frame);
                    }
                    finally
                    {
                        idleOperation.Abort();
                        dispatcher.Hooks.OperationCompleted -= onOperationCompleted;
                        dispatcher.Hooks.OperationPosted -= onOperationPosted;
                        dispatcher.Hooks.DispatcherInactive -= onDispatcherInactive;
                    }
    
                    return result;
                }
            }
    
            const uint QS_EVENTMASK = 0x1FF;
            const uint MWMO_INPUTAVAILABLE = 0x4;
            const uint WAIT_TIMEOUT = 0x102;
            const uint WAIT_OBJECT_0 = 0;
            const uint WAIT_ABANDONED_0 = 0x80;
            const uint INFINITE = 0xFFFFFFFF;
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint MsgWaitForMultipleObjectsEx(
                uint nCount, IntPtr[] pHandles,
                uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
    
            [DllImport("kernel32.dll")]
            static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        }
        #endregion
    }
