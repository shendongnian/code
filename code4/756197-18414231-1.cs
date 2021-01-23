    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Diagnostics;
    using Microsoft.Win32;
    
    namespace WinformsWB
    {
        public partial class Form1 : Form
        {
             public Form1()
            {
                SetBrowserFeatureControl();
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.webBrowser1.ScriptErrorsSuppressed = true;
                this.webBrowser1.Navigate("http://www.popuptest.com/");
            }
    
            private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
            {
                using (var key = Registry.CurrentUser.CreateSubKey(
                    String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                    RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
                }
            }
    
            private void SetBrowserFeatureControl()
            {
                // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
                // FeatureControl settings are per-process
                var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
                // make the control is not running inside Visual Studio Designer
                if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                    return;
    
                // TODO: FEATURE_BROWSER_MODE - what is it?
                SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 9000); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
                SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
                SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 1);
                SetBrowserFeatureControlKey("FEATURE_BLOCK_INPUT_PROMPTS", fileName, 1);
            }
        }
    }
