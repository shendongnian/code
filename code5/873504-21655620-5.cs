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
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                try
                {
                    Func<Task> doAsync = async () =>
                    {
                        await Task.Delay(10000);
                    };
    
                    var task = doAsync();
                    var handle = ((IAsyncResult)task).AsyncWaitHandle;
    
                    var startTick = Environment.TickCount;
                    handle.WaitOneAndPump(15000);
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
                    bool result = false;
                    Exception error = null;
    
                    var startTick = Environment.TickCount;
    
                    var handles = new[] { 
                            handle.SafeWaitHandle.DangerousGetHandle(), 
                            operationPendingMre.SafeWaitHandle.DangerousGetHandle() };
    
                    var dispatcher = Dispatcher.CurrentDispatcher;
    
                    var frame = new DispatcherFrame();
    
                    var getTimeout = (Timeout.Infinite == millisecondsTimeout) ?
                        new Func<uint>(() => INFINITE) :
                        new Func<uint>(() => (uint)Math.Max(0, 
                            millisecondsTimeout + startTick - Environment.TickCount));
    
                    DispatcherHookEventHandler onOperationPosted = (s, e) =>
                    {
                        // this may occur on a random thread,
                        // trigger a helper event and 
                        // unblock MsgWaitForMultipleObjectsEx inside onDispatcherInactive
                        operationPendingMre.Set();
                    };
    
                    DispatcherHookEventHandler onOperationCompleted = (s, e) =>
                    {
                        // this should occur on the Dispather thread
                        Debug.Assert(Thread.CurrentThread == dispatcher.Thread);
    
                        // do an instant handle check
                        var nativeResult = WaitForSingleObject(handles[0], 0);
                        if (nativeResult == WAIT_OBJECT_0)
                            result = true;
                        else if (nativeResult == WAIT_ABANDONED_0)
                            error = new AbandonedMutexException(-1, handle);
                        else if (getTimeout() == 0)
                            result = false;
                        else if (nativeResult == WAIT_TIMEOUT)
                            return;
                        else
                            error = new InvalidOperationException("WaitForSingleObject");
    
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
                            result = true; // handle signalled
                        else if (nativeResult == WAIT_TIMEOUT)
                            result = false; // timed-out
                        else if (nativeResult == WAIT_ABANDONED_0)
                            error = new AbandonedMutexException(-1, handle);
                        else if (nativeResult != WAIT_OBJECT_0 + 1 && nativeResult != WAIT_OBJECT_0 + 2)
                            error = new InvalidOperationException("MsgWaitForMultipleObjectsEx");
                        else
                        {
                            // a Windows message or a Dispatcher operation is pending
                            if (timeout == 0)
                                result = false; // timed-out
                            else
                                return;
                        }
    
                        // end the nested Dispatcher loop
                        frame.Continue = false;
                    };
    
                    dispatcher.Hooks.OperationCompleted += onOperationCompleted;
                    dispatcher.Hooks.OperationPosted += onOperationPosted;
                    dispatcher.Hooks.DispatcherInactive += onDispatcherInactive;
    
                    try
                    {
                        // onDispatcherInactive will be called on the new frame,
                        // as soon as Dispatcher becomes idle
                        Dispatcher.PushFrame(frame);
                    }
                    finally
                    {
                        dispatcher.Hooks.OperationCompleted -= onOperationCompleted;
                        dispatcher.Hooks.OperationPosted -= onOperationPosted;
                        dispatcher.Hooks.DispatcherInactive -= onDispatcherInactive;
                    }
    
                    if (error != null)
                        throw error;
    
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
