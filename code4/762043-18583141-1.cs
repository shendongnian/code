    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WbTest
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
    			DoNavigationAsync().ContinueWith(_ =>
    			{
    				MessageBox.Show("Navigation complete!");
    			}, TaskScheduler.FromCurrentSynchronizationContext());
    		}
    
    		private async Task DoNavigationAsync()
    		{
    			TaskCompletionSource<bool> documentCompleteTcs = null;
    
    			WebBrowserDocumentCompletedEventHandler handler = delegate 
    			{
    				if (documentCompleteTcs.Task.IsCompleted)
    					return;
    				documentCompleteTcs.SetResult(true);
    			};
    
    			documentCompleteTcs = new TaskCompletionSource<bool>();
    			this.wb.DocumentCompleted += handler;
    
    			// could do this.wb.Navigate(url) here 
    			this.wb.DocumentText = "<!DOCTYPE html><head><meta http-equiv='X-UA-Compatible' content='IE=edge'/></head>"+
    				"<body><input size=50 type='text' placeholder='HTML5 if this placeholder is visible'/></body>";
    			 
    			await documentCompleteTcs.Task;
    			this.wb.DocumentCompleted -= handler;
    
    			dynamic document = this.wb.Document.DomDocument;
    			dynamic navigator = document.parentWindow.navigator;
    			var info =
    				"\n navigator.userAgent: " + navigator.userAgent +
    				"\n navigator.appName: " + navigator.appName +
    				"\n document.documentMode: " + document.documentMode +
    				"\n document.compatMode: " + document.compatMode;
    
    			MessageBox.Show(info);
    		}
    
    		private static void SetBrowserFeatureControl()
    		{
    			// http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
    			// WebBrowser Feature Control settings are per-process
    			var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
    			// make the control is not running inside Visual Studio Designer
    			if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
    				return;
    
    			SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); 
    		}
    
    		private static void SetBrowserFeatureControlKey(string feature, string appName, uint value)
    		{
    			using (var key = Registry.CurrentUser.CreateSubKey(
    				String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
    				RegistryKeyPermissionCheck.ReadWriteSubTree))
    			{
    				key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
    			}
    		}
    
    		private static UInt32 GetBrowserEmulationMode()
    		{
    			int browserVersion = 7;
    			using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
    				RegistryKeyPermissionCheck.ReadSubTree,
    				System.Security.AccessControl.RegistryRights.QueryValues))
    			{
    				var version = ieKey.GetValue("svcVersion");
    				if (null == version)
    				{
    					version = ieKey.GetValue("Version");
    					if (null == version)
    						throw new ApplicationException("Microsoft Internet Explorer is required!");
    				}
    				int.TryParse(version.ToString().Split('.')[0], out browserVersion);
    			}
    
    			// Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
    			UInt32 mode = 10000; 
    
    			switch (browserVersion)
    			{
    				case 7:
    					// Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
    					mode = 7000;                     
    					break;
    				case 8:
    					// Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
    					mode = 8000; 
    					break;
    				case 9:
    					// Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
    					mode = 9000; 
    					break;
    				default:
    					// use IE10 mode by default
    					break;
    			}
    
    			return mode;
    		}
    	}
    }
