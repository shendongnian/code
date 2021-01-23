    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WebAutomation
    {
    	// http://stackoverflow.com/q/19044659/1768303
    
    	public partial class MainForm : Form
    	{
    		WebBrowser webBrowser;
    
    		// non-deterministic delay to let AJAX code run
    		const int AJAX_DELAY = 1000;
    
    		// keep track of the main automation task
    		CancellationTokenSource mainCts;
    		Task mainTask = null;
    
    		public MainForm()
    		{
    			SetBrowserFeatureControl(); // set FEATURE_BROWSER_EMULATION first
    
    			InitializeComponent();
    
    			InitBrowser();
    
    			this.Load += (s, e) =>
    			{
    				// start the automation when form is loaded
    				// timeout the whole automation task in 30s
    				mainCts = new CancellationTokenSource(30000);
    				mainTask = DoAutomationAsync(mainCts.Token).ContinueWith((completedTask) =>
    				{
    					Trace.WriteLine(String.Format("Automation task status: {0}", completedTask.Status.ToString()));
    				}, TaskScheduler.FromCurrentSynchronizationContext());
    			};
    
    			this.FormClosing += (s, e) =>
    			{
    				// cancel the automation if form closes
    				if (this.mainTask != null && !this.mainTask.IsCompleted)
    					mainCts.Cancel();
    			};
    		}
    
    		// create a WebBrowser instance (could use an existing one)
    		void InitBrowser()
    		{
    			this.webBrowser = new WebBrowser();
    			this.webBrowser.Dock = DockStyle.Fill;
    			this.Controls.Add(this.webBrowser);
    			this.webBrowser.Visible = true;
    		}
    
    		// the main automation logic
    		async Task DoAutomationAsync(CancellationToken ct)
    		{
    			await NavigateAsync(ct, () => this.webBrowser.Navigate("http://localhost:81/test.html"), 10000); // timeout in 10s
    			// page loaded, log the page's HTML
    			Trace.WriteLine(GetBrowserDocumentHtml());
    
    			// do the DOM automation
    			HtmlElementCollection all = webBrowser.Document.GetElementsByTagName("button");
    			// throw if none or more than one element found
    			HtmlElement btn = all.Cast<HtmlElement>().Single(
    				el => el.InnerHtml == "ACCEPT the terms of use");
    
    			ct.ThrowIfCancellationRequested();
    
    			// simulate a click which causes navigation
    			await NavigateAsync(ct, () => btn.InvokeMember("click"), 10000); // timeout in 10s
    
    			// form submitted and new page loaded, log the page's HTML
    			Trace.WriteLine(GetBrowserDocumentHtml());
    
    			// could continue with another NavigateAsync
    			// othrwise, the automation session completed
    		}
    
    		// Get the full HTML content of the document
    		string GetBrowserDocumentHtml()
    		{
    			return this.webBrowser.Document.GetElementsByTagName("html")[0].OuterHtml;
    		}
    
    		// Async navigation
    		async Task NavigateAsync(CancellationToken ct, Action startNavigation, int timeout = Timeout.Infinite)
    		{
    			var onloadTcs = new TaskCompletionSource<bool>();
    			EventHandler onloadEventHandler = null;
    
    			WebBrowserDocumentCompletedEventHandler documentCompletedHandler = delegate
    			{
    				// DocumentCompleted may be called several time for the same page,
    				// beacuse of frames
    				if (onloadEventHandler != null || onloadTcs == null || onloadTcs.Task.IsCompleted)
    					return;
    
    				// handle DOM onload event to make sure the document is fully loaded
    				onloadEventHandler = (s, e) =>
    					onloadTcs.TrySetResult(true);
    				this.webBrowser.Document.Window.AttachEventHandler("onload", onloadEventHandler);
    			};
    
    			using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
    			{
    				if (timeout != Timeout.Infinite)
    					cts.CancelAfter(Timeout.Infinite);
    
    				using (cts.Token.Register(() => onloadTcs.TrySetCanceled(), useSynchronizationContext: true)) 
    				{
    					this.webBrowser.DocumentCompleted += documentCompletedHandler;
    					try 
    					{
    						startNavigation();
    						// wait for DOM onload, throw if cancelled
    						await onloadTcs.Task;
    						ct.ThrowIfCancellationRequested();
    						// let AJAX code run, throw if cancelled
    						await Task.Delay(AJAX_DELAY, ct);
    					}
    					finally 
    					{
    						this.webBrowser.DocumentCompleted -= documentCompletedHandler;
    						if (onloadEventHandler != null)
    							this.webBrowser.Document.Window.DetachEventHandler("onload", onloadEventHandler);
    					}
    				}
    			}
    		}
    
    		// Browser feature conntrol
    		void SetBrowserFeatureControl()
    		{
    			// http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
    			// FeatureControl settings are per-process
    			var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
    			// make the control is not running inside Visual Studio Designer
    			if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
    				return;
    
    			SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
    		}
    
    		void SetBrowserFeatureControlKey(string feature, string appName, uint value)
    		{
    			using (var key = Registry.CurrentUser.CreateSubKey(
    				String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
    				RegistryKeyPermissionCheck.ReadWriteSubTree))
    			{
    				key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
    			}
    		}
    
    		UInt32 GetBrowserEmulationMode()
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
    
    			UInt32 mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
    			switch (browserVersion)
    			{
    				case 7:
    					mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
    					break;
    				case 8:
    					mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
    					break;
    				case 9:
    					mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
    					break;
    				default:
    					// use IE10 mode by default
    					break;
    			}
    
    			return mode;
    		}
    	}
    }
