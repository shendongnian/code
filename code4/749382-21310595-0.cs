    using System;
    using System.Windows.Forms;
    using Xilium.CefGlue;
    using Xilium.CefGlue.WindowsForms;
    namespace CefGlue3
    {
      public partial class Form1 : Form
      {
        private CefWebBrowser browser;
        public Form1()
        {
          InitializeCef();
          InitializeComponent();
        }
        private static void InitializeCef()
        {
          CefRuntime.Load();
          CefMainArgs cefArgs = new CefMainArgs(new[] {"--force-renderer-accessibility"});
          CefApplication cefApp = new CefApplication();
          CefRuntime.ExecuteProcess(cefArgs, cefApp);
          CefSettings cefSettings = new CefSettings
          {
            SingleProcess = false, 
            MultiThreadedMessageLoop = true, 
            LogSeverity = CefLogSeverity.ErrorReport, 
            LogFile = "CefGlue.log",
          };
          CefRuntime.Initialize(cefArgs, cefSettings, cefApp);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          browser = new CefWebBrowser
          {
            Visible = true,
            //StartUrl = "http://www.google.com",
            Dock = DockStyle.Fill,
            Parent = this
          };
          Controls.Add(browser);
          browser.BrowserCreated += BrowserOnBrowserCreated;
        }
        private void BrowserOnBrowserCreated(object sender, EventArgs eventArgs)
        {
          browser.Browser.GetMainFrame().LoadUrl("http://www.google.com");
        }
      }
    }
    using Xilium.CefGlue;
    namespace CefGlue3
    {
      internal sealed class CefApplication : CefApp
      {
        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
          return new RenderProcessHandler();
        }
      }
      internal sealed class RenderProcessHandler : CefRenderProcessHandler
      {
        protected override void OnWebKitInitialized()
        {
          CefRuntime.RegisterExtension("testExtension", "var test;if (!test)test = {};(function() {test.myval = 'My Value!';})();", null);
          base.OnWebKitInitialized();
        }
      }
    }
