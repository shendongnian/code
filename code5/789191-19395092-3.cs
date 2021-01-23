    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WebBrowserAuthApp
    {
    	[ComVisible(true)]
    	[ClassInterface(ClassInterfaceType.None)]
    	public partial class MainForm : Form,
    		ComExt.IServiceProvider,
    		ComExt.IAuthenticate
    	{
    		WebBrowser webBrowser;
    		uint _authenticateServiceCookie = ComExt.INVALID;
    		ComExt.IProfferService _profferService = null;
    
    		CancellationTokenSource _navigationCts = null;
    		Task _navigationTask = null;
    
    		public MainForm()
    		{
    			SetBrowserFeatureControl();
    			
    			InitializeComponent();
    			
    			InitBrowser();
    
    			this.Load += (s, e) =>
    			{
    				_navigationCts = new CancellationTokenSource();
    				_navigationTask = DoNavigationAsync(_navigationCts.Token);
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
    
    		// main navigation task
    		async Task DoNavigationAsync(CancellationToken ct)
    		{
    			// navigate to a blank page first to initialize webBrowser.ActiveXInstance
    			await NavigateAsync(ct, "about:blank");
    
    			// set up IAuthenticate as service via IProfferService
    			var ax = this.webBrowser.ActiveXInstance;
    			var serviceProvider = (ComExt.IServiceProvider)ax;
    			serviceProvider.QueryService(out _profferService);
    			_profferService.ProfferService(typeof(ComExt.IAuthenticate).GUID, this, ref _authenticateServiceCookie);
    
    			// navigate to a website which requires basic authentication
    			// e.g.: http://www.httpwatch.com/httpgallery/authentication/
    			string html = await NavigateAsync(ct, "http://www.httpwatch.com/httpgallery/authentication/authenticatedimage/default.aspx");
    			MessageBox.Show(html);
    		}
    
    		// asynchronous navigation
    		async Task<string> NavigateAsync(CancellationToken ct, string url)
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
    
    			try
    			{
    				this.webBrowser.DocumentCompleted += documentCompletedHandler;
    				using (ct.Register(() => onloadTcs.TrySetCanceled(), useSynchronizationContext: true))
    				{
    					this.webBrowser.Navigate(url);
    					// wait for DOM onload, throw if cancelled
    					await onloadTcs.Task;
    				}
    			}
    			finally
    			{
    				this.webBrowser.DocumentCompleted -= documentCompletedHandler;
    				if (onloadEventHandler != null)
    					this.webBrowser.Document.Window.DetachEventHandler("onload", onloadEventHandler);
    			}
    
    			return this.webBrowser.Document.GetElementsByTagName("html")[0].OuterHtml;
    		}
    
    		// shutdown
    		protected override void OnClosed(EventArgs e)
    		{
    			if (_navigationCts != null && _navigationCts != null && !_navigationTask.IsCompleted)
    			{
    				_navigationCts.Cancel();
    				_navigationCts.Dispose();
    				_navigationCts = null;
    			}
    			if (_authenticateServiceCookie != ComExt.INVALID)
    			{
    				_profferService.RevokeService(_authenticateServiceCookie);
    				_authenticateServiceCookie = ComExt.INVALID;
    				Marshal.ReleaseComObject(_profferService);
    				_profferService = null;
    			}
    		}
    
    		#region ComExt.IServiceProvider
    		public int QueryService(ref Guid guidService, ref Guid riid, ref IntPtr ppvObject)
    		{
    			if (guidService == typeof(ComExt.IAuthenticate).GUID)
    			{
    				return this.QueryInterface(ref riid, ref ppvObject);
    			}
    			return ComExt.E_NOINTERFACE;
    		}
    		#endregion
    
    		#region ComExt.IAuthenticate
    		public int Authenticate(ref IntPtr phwnd, ref string pszUsername, ref string pszPassword)
    		{
    			phwnd = IntPtr.Zero;
    			pszUsername = "httpwatch";
    			pszPassword = String.Empty;
    			return ComExt.S_OK;
    		}
    		#endregion
    
    		// Browser version control
    		// http://msdn.microsoft.com/en-us/library/ee330730(v=vs.85).aspx#browser_emulation
    		private void SetBrowserFeatureControl()
    		{
    			// FeatureControl settings are per-process
    			var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
    			// make the control is not running inside Visual Studio Designer
    			if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
    				return;
    
    			// Webpages containing standards-based !DOCTYPE directives are displayed in IE9/IE10 Standards mode.
    			SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 9000);
    		}
    
    		private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
    		{
    			// http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    			using (var key = Registry.CurrentUser.CreateSubKey(
    				String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
    				RegistryKeyPermissionCheck.ReadWriteSubTree))
    			{
    				key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
    			}
    		}
    
    	}
    
    	// COM interfaces and helpers
    	public static class ComExt
    	{
    		public const int S_OK = 0;
    		public const int E_NOINTERFACE = unchecked((int)0x80004002);
    		public const int E_UNEXPECTED = unchecked((int)0x8000ffff);
    		public const int E_POINTER = unchecked((int)0x80004003);
    		public const uint INVALID = unchecked((uint)-1);
    
    		static public void QueryService<T>(this IServiceProvider serviceProvider, out T service) where T : class
    		{
    			Type type = typeof(T);
    			IntPtr unk = IntPtr.Zero;
    			int result = serviceProvider.QueryService(type.GUID, type.GUID, ref unk);
    			if (unk == IntPtr.Zero || result != S_OK)
    				throw new COMException(
    					new StackFrame().GetMethod().Name,
    					result != S_OK ? result : E_UNEXPECTED);
    			try
    			{
    				service = (T)Marshal.GetTypedObjectForIUnknown(unk, type);
    			}
    			finally
    			{
    				Marshal.Release(unk);
    			}
    		}
    
    		static public int QueryInterface(this object provider, ref Guid riid, ref IntPtr ppvObject)
    		{
    			if (ppvObject != IntPtr.Zero)
    				return E_POINTER;
    
    			IntPtr unk = Marshal.GetIUnknownForObject(provider);
    			try
    			{
    				return Marshal.QueryInterface(unk, ref riid, out ppvObject);
    			}
    			finally
    			{
    				Marshal.Release(unk);
    			}
    		}
    
    		#region IServiceProvider Interface
    		[ComImport()]
    		[Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		public interface IServiceProvider
    		{
    			[PreserveSig]
    			int QueryService(
    				[In] ref Guid guidService,
    				[In] ref Guid riid,
    				[In, Out] ref IntPtr ppvObject);
    		}
    		#endregion
    
    		#region IProfferService Interface
    		[ComImport()]
    		[Guid("cb728b20-f786-11ce-92ad-00aa00a74cd0")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		public interface IProfferService
    		{
    			void ProfferService(ref Guid guidService, IServiceProvider psp, ref uint cookie);
    
    			void RevokeService(uint cookie);
    		}
    		#endregion
    
    		#region IAuthenticate Interface
    		[ComImport()]
    		[Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		public interface IAuthenticate
    		{
    			[PreserveSig]
    			int Authenticate([In, Out] ref IntPtr phwnd,
    				[In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string pszUsername,
    				[In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string pszPassword);
    		}
    		#endregion
    	}
    }
