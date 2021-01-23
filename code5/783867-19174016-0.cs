    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Reflection;
    
    namespace WpfWebBrowser
    {
        // http://stackoverflow.com/q/19170109/1768303
    
        public partial class MainWindow : Window
        {
            static object GetActiveXInstance(WebBrowser wb) {
                // get the underlying WebBrowser ActiveX object;
                // this code depends on SHDocVw.dll COM interop assembly,
                // generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
                // and add as a reference to the project
    
                return wb.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, wb, new object[] { }) as SHDocVw.WebBrowser;
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += (s, e) =>
                {
                    var axWbMainV1 = (SHDocVw.WebBrowser_V1)GetActiveXInstance(this.wbMaster);
                    var axWbSlaveV1 = (SHDocVw.WebBrowser_V1)GetActiveXInstance(this.wbSlave);
    
                    var manualNavigation = false;
    
                    // Use WebBrowser_V1 events as BeforeNavigate2 doesn't work with WPF WebBrowser
                    axWbMainV1.BeforeNavigate += (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Cancel) =>
                    {
                        if (!manualNavigation)
                            return;
                        Cancel = true;
                        axWbMainV1.Stop();
                        axWbSlaveV1.Navigate(URL, Flags, TargetFrameName, PostData, Headers);
                    };
    
                    axWbMainV1.FrameBeforeNavigate += (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Cancel) =>
                    {
                        if (!manualNavigation)
                            return;
                        Cancel = true;
                        axWbMainV1.Stop();
                        axWbSlaveV1.Navigate(URL, Flags, TargetFrameName, PostData, Headers);
                    };
    
                    axWbMainV1.NavigateComplete += (string URL) =>
                    {
                        manualNavigation = true;
                    };
                    
                    axWbMainV1.FrameNavigateComplete += (string URL) =>
                    {
                        manualNavigation = true;
                    };
    
                    axWbMainV1.NewWindow += (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed) =>
                    {
                        if (!manualNavigation)
                            return;
                        Processed = true;
                        axWbMainV1.Stop();
                        axWbSlaveV1.Navigate(URL, Flags, String.Empty, PostData, Headers);
                    };
    
                    manualNavigation = false;
                    axWbMainV1.Navigate("http://www.w3.org/");
                };
            }
        }
    }
