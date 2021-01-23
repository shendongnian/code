    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfWebBrowser
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			SetBrowserFeatureControl();
    			InitializeComponent();
    
    			this.Loaded += MainWindow_Loaded;
    		}
    
    		async void MainWindow_Loaded(object sender, RoutedEventArgs eventArg)
    		{
    			// navigate the browser
    			System.Windows.Navigation.LoadCompletedEventHandler loadedHandler = null;
    			var loadedTcs = new TaskCompletionSource<bool>();
    
    			loadedHandler = (s, e) =>
    			{
    				this.webBrowser.LoadCompleted -= loadedHandler;
    				loadedTcs.SetResult(true);
    			};
    
    			this.webBrowser.LoadCompleted += loadedHandler;
    			this.webBrowser.Navigate("http://localhost:81/callback.html");
    			await loadedTcs.Task;
    
    			// call the script method "scriptFuncAsync"
    			var asyncScriptTcs = new TaskCompletionSource<object>();
    			var oncompleted = new ScriptEventHandler((ref object returnResult, object[] args) => 
    			{
    				// we are here when the script has called us back
    				asyncScriptTcs.SetResult(args[0]);
    			});
    
    			this.webBrowser.InvokeScript("scriptFuncAsync", oncompleted);
    			await asyncScriptTcs.Task;
    
    			// show the result of the asyc call
    			dynamic result = asyncScriptTcs.Task.Result;
    			MessageBox.Show(result.outcome.ToString());
    		}
    
    
    		/// <summary>
    		/// ScriptEventHandler - an adaptor to call C# back from JavaScript or DOM event handlers
    		/// </summary>
    		[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    		public class ScriptEventHandler
    		{
    			[ComVisible(false)]
    			public delegate void Callback(ref object returnResult, params object[] args);
    
    			[ComVisible(false)]
    			private Callback _callback;
    
    			[DispId(0)]
    			public object Method(params object[] args)
    			{
    				var returnResult = Type.Missing; // Type.Missing is "undefined" in JavaScript
    				_callback(ref returnResult, args);
    				return returnResult;
    			}
    
    			public ScriptEventHandler(Callback callback)
    			{
    				_callback = callback;
    			}
    		}
    
    		/// <summary>
    		/// WebBrowser version control to enable HTML5
    		/// http://msdn.microsoft.com/en-us/library/ee330730(v=vs.85).aspx#browser_emulation
    		/// </summary>
    		void SetBrowserFeatureControl()
    		{
    			// http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx
    
    			// FeatureControl settings are per-process
    			var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
    
    			// make the control is not running inside Visual Studio Designer
    			if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
    				return;
    
    			// Webpages containing standards-based !DOCTYPE directives are displayed in IE9/IE10 Standards mode.
    			SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, 9000);
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
    
    	}
    }
