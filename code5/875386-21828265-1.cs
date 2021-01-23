    using Microsoft.Win32;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Console_21697048
    {
        // http://stackoverflow.com/q/21697048/1768303
        class Program
        {
            const string HTML = "<!DOCTYPE html><body style='background-color: grey'><div style='background-color: blue; opacity: 0.2; color: yellow'>This is a text</div></body>";
            const string FILE_NAME = "webpage.png";
            readonly static Size IMAGE_SIZE = new Size(320, 200); 
    
            // Main
            static void Main(string[] args)
            {
                try
                {
                    // enable HTML5 etc (assuming we're running IE9+)
                    SetFeatureBrowserFeature("FEATURE_BROWSER_EMULATION", 9000);
                    // force software rendering
                    SetFeatureBrowserFeature("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI", 1);
                    SetFeatureBrowserFeature("FEATURE_GPU_RENDERING", 0);
    
                    using (var apartment = new MessageLoopApartment())
                    {
                        // create WebBrowser on a seprate thread with its own message loop
                        var webBrowser = apartment.Invoke(() => new WebBrowser());
    
                        // navigate and wait for the result 
                        apartment.Invoke(() =>
                        {
                            var pageLoadedTcs = new TaskCompletionSource<bool>();
                            webBrowser.DocumentCompleted += (s, e) =>
                                pageLoadedTcs.TrySetResult(true);
    
                            webBrowser.DocumentText = HTML;
                            return pageLoadedTcs.Task;
                        }).Wait();
    
                        // save the picture
                        apartment.Invoke(() =>
                        {
                            webBrowser.Size = IMAGE_SIZE;
                            var rectangle = new Rectangle(0, 0, webBrowser.Width, webBrowser.Height);
    
                            // get reference DC
                            using (var screenGraphics = webBrowser.CreateGraphics())
                            {
                                var screenHdc = screenGraphics.GetHdc();
                                // create a metafile
                                using (var metafile = new Metafile(screenHdc, rectangle, MetafileFrameUnit.Pixel))
                                {
                                    using (var graphics = Graphics.FromImage(metafile))
                                    {
                                        var hdc = graphics.GetHdc();
                                        var rect = new Rectangle(0, 0, 320, 50);
                                        OleDraw(webBrowser.ActiveXInstance, DVASPECT_CONTENT, hdc, ref rectangle);
                                        graphics.ReleaseHdc(hdc);
                                    }
                                    // save the metafile as bitmap
                                    metafile.Save(FILE_NAME, ImageFormat.Png);
                                }
                                screenGraphics.ReleaseHdc(screenHdc);
                            }
                        });
    
                        // dispose of webBrowser
                        apartment.Invoke(() => webBrowser.Dispose());
                        webBrowser = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
    
            // interop
            const uint DVASPECT_CONTENT = 1;
    
            [DllImport("ole32.dll", PreserveSig = false)]
            static extern void OleDraw(
                [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
                uint dwAspect,
                IntPtr hdcDraw,
                [In] ref System.Drawing.Rectangle lprcBounds);
    
            // WebBrowser Feature Control
            // http://msdn.microsoft.com/en-us/library/ie/ee330733(v=vs.85).aspx
            static void SetFeatureBrowserFeature(string feature, uint value)
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                    return;
                var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\" + feature,
                    appName, value, RegistryValueKind.DWord);
            }
        }
    
    
        // MessageLoopApartment
        // more info: http://stackoverflow.com/a/21808747/1768303
    
        public class MessageLoopApartment : IDisposable
        {
            Thread _thread; // the STA thread
    
            TaskScheduler _taskScheduler; // the STA thread's task scheduler
    
            public TaskScheduler TaskScheduler { get { return _taskScheduler; } }
    
            /// <summary>MessageLoopApartment constructor</summary>
            public MessageLoopApartment()
            {
                var tcs = new TaskCompletionSource<TaskScheduler>();
    
                // start an STA thread and gets a task scheduler
                _thread = new Thread(startArg =>
                {
                    EventHandler idleHandler = null;
    
                    idleHandler = (s, e) =>
                    {
                        // handle Application.Idle just once
                        Application.Idle -= idleHandler;
                        // return the task scheduler
                        tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
                    };
    
                    // handle Application.Idle just once
                    // to make sure we're inside the message loop
                    // and SynchronizationContext has been correctly installed
                    Application.Idle += idleHandler;
                    Application.Run();
                });
    
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.IsBackground = true;
                _thread.Start();
                _taskScheduler = tcs.Task.Result;
            }
    
            /// <summary>shutdown the STA thread</summary>
            public void Dispose()
            {
                if (_taskScheduler != null)
                {
                    var taskScheduler = _taskScheduler;
                    _taskScheduler = null;
    
                    // execute Application.ExitThread() on the STA thread
                    Task.Factory.StartNew(
                        () => Application.ExitThread(),
                        CancellationToken.None,
                        TaskCreationOptions.None,
                        taskScheduler).Wait();
    
                    _thread.Join();
                    _thread = null;
                }
            }
    
            /// <summary>Task.Factory.StartNew wrappers</summary>
            public void Invoke(Action action)
            {
                Task.Factory.StartNew(action, 
                    CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
            }
    
            public TResult Invoke<TResult>(Func<TResult> action)
            {
                return Task.Factory.StartNew(action,
                    CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
            }
        }
    }
