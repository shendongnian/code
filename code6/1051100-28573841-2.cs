    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Threading;
    
    namespace LegacyWinApp
    {
    	// by noseratio - https://stackoverflow.com/a/28573841/1768303
    
    	/// <summary>
    	/// Form1 - testing MyComVisibleClass from a client app
    	/// </summary>
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    			this.Load += Form1_Load;
    		}
    
    		private void Form1_Load(object sender, EventArgs e)
    		{
    			var comObject = new MyComVisibleClass();
    
    			var status = new Label { Left = 10, Top = 10, Width = 50, Height = 25, BorderStyle = BorderStyle.Fixed3D };
    			this.Controls.Add(status);
    
    			comObject.Loaded += () =>
    				status.Text = "Loaded!";
    
    			comObject.Closed += () =>
    				status.Text = "Closed!";
    
    			var buttonOpen = new Button { Left = 10, Top = 60, Width = 50, Height = 50, Text = "Open" };
    			this.Controls.Add(buttonOpen);
    			buttonOpen.Click += (_, __) =>
    			{
    				comObject.Open();
    				status.Text = "Opened!";
    				comObject.Load("http://example.com");
    			};
    
    			var buttonClose = new Button { Left = 10, Top = 110, Width = 50, Height = 50, Text = "Close" };
    			this.Controls.Add(buttonClose);
    			buttonClose.Click += (_, __) =>
    				comObject.Close();
    		}
    	}
    
    	/// <summary>
    	/// MyComVisibleClass
    	/// </summary>
    
    	[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    	public interface IComObject
    	{
    		void Open();
    		void Load(string url);
    		void Close();
    	}
    
    	[ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    	public interface IComObjectEvents
    	{
    		void Loaded();
    		void Closed();
    	}
    
    	/// <summary>
    	/// MyComVisibleClass
    	/// </summary>
    	[ComVisible(true)]
    	[ClassInterface(ClassInterfaceType.None)]
    	[ComDefaultInterface(typeof(IComObject))]
    	[ComSourceInterfaces(typeof(IComObjectEvents))]
    	public class MyComVisibleClass : IComObject
    	{
    		internal class EventHelper
    		{
    			MyComVisibleClass _parent;
    			System.Windows.Threading.Dispatcher _clientThreadDispatcher;
    
    			internal EventHelper(MyComVisibleClass parent)
    			{
    				_parent = parent;
    				_clientThreadDispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
    			}
    
    			public void FireLoaded()
    			{
    				_clientThreadDispatcher.InvokeAsync(() =>
    					_parent.FireLoaded());
    			}
    
    			public void FireClosed()
    			{
    				_clientThreadDispatcher.InvokeAsync(() =>
    					_parent.FireClosed());
    			}
    		}
    
    		WpfApartment _wpfApartment;
    		BrowserWindow _browserWindow;
    		readonly EventHelper _eventHelper;
    
    		public MyComVisibleClass()
    		{
    			_eventHelper = new EventHelper(this);
    		}
    
    		// IComObject methods
    
    		public void Open()
    		{
    			if (_wpfApartment != null)
    				throw new InvalidOperationException();
    
    			// start a new thread with WPF Dispatcher
    			_wpfApartment = new WpfApartment();
    
    			// attach the input queue of the current thread to that of c
    			var thisThreadId = NativeMethods.GetCurrentThreadId();
    			_wpfApartment.Invoke(() =>
    				NativeMethods.AttachThreadInput(thisThreadId, NativeMethods.GetCurrentThreadId(), true));
    
    			// create an instance of BrowserWindow on the WpfApartment's thread
    			_browserWindow = _wpfApartment.Invoke(() => new BrowserWindow(_eventHelper) { 
    				Left = 200, Top = 200, Width = 640, Height = 480 });
    			_wpfApartment.Invoke(() => _browserWindow.Initialize());
    		}
    
    		public void Load(string url)
    		{
    			if (_wpfApartment == null)
    				throw new InvalidOperationException();
    
    			_wpfApartment.Run(async () =>
    			{
    				try
    				{
    					await _browserWindow.LoadAsync(url);
    					_eventHelper.FireLoaded();
    				}
    				catch (Exception ex)
    				{
    					System.Windows.MessageBox.Show(ex.Message);
    					throw;
    				}
    			});
    		}
    
    		public void Close()
    		{
    			if (_wpfApartment == null)
    				return;
    
    			if (_browserWindow != null)
    				_wpfApartment.Invoke(() => 
    					_browserWindow.Close());
    
    			CloseWpfApartment();
    		}
    
    		void CloseWpfApartment()
    		{
    			if (_wpfApartment != null)
    			{
    				_wpfApartment.Dispose();
    				_wpfApartment = null;
    			}
    		}
    
    		// IComObjectEvents events
    
    		public event Action Loaded = EmptyEventHandler;
    
    		public event Action Closed = EmptyEventHandler;
    
    		// fire events, to be called by EventHelper
    
    		static void EmptyEventHandler() { }
    
    		internal void FireLoaded()
    		{
    			this.Loaded();
    		}
    
    		internal void FireClosed()
    		{
    			_browserWindow = null;
    			CloseWpfApartment();            
    			this.Closed();
    		}
    	}
    
    	/// <summary>
    	/// BrowserWindow
    	/// </summary>
    	class BrowserWindow: System.Windows.Window
    	{
    		System.Windows.Controls.WebBrowser _browser;
    		MyComVisibleClass.EventHelper _events;
    
    		public BrowserWindow(MyComVisibleClass.EventHelper events)
    		{
    			_events = events;
    			this.Visibility = System.Windows.Visibility.Hidden;
    			this.ShowActivated = true;
    			this.ShowInTaskbar = false;
    		}
    
    		bool IsReady()
    		{
    			return (this.Visibility != System.Windows.Visibility.Hidden && _browser != null);
    		}
    
    		public void Initialize()
    		{
    			if (IsReady())
    				throw new InvalidOperationException();
    
    			this.Show();
    			_browser = new System.Windows.Controls.WebBrowser();
    			this.Content = _browser;
    		}
    
    		public async Task LoadAsync(string url)
    		{
    			if (!IsReady())
    				throw new InvalidOperationException();
    
    			// navigate and handle LoadCompleted
    			var navigationTcs = new TaskCompletionSource<bool>();
    
    			System.Windows.Navigation.LoadCompletedEventHandler handler = (s, e) =>
    				navigationTcs.TrySetResult(true);
    
    			_browser.LoadCompleted += handler;
    			try
    			{
    				_browser.Navigate(url);
    				await navigationTcs.Task;
    			}
    			finally
    			{
    				_browser.LoadCompleted -= handler;
    			}
    
    			// make the content editable to check if WebBrowser shortcuts work well
    			dynamic doc = _browser.Document;
    			doc.body.firstChild.contentEditable = true;
    			_events.FireLoaded();
    		}
    
    		protected override void OnClosed(EventArgs e)
    		{
    			base.OnClosed(e);
    			_browser.Dispose();
    			_browser = null;
    			_events.FireClosed();
    		}
    	}
    
    	/// <summary>
    	/// WpfApartment
    	/// </summary>
    	internal class WpfApartment : IDisposable
    	{
    		Thread _thread; // the STA thread
    
    		TaskScheduler _taskScheduler; // the STA thread's task scheduler
    
    		public TaskScheduler TaskScheduler { get { return _taskScheduler; } }
    
    		// start the STA thread with WPF Dispatcher
    		public WpfApartment()
    		{
    			var tcs = new TaskCompletionSource<TaskScheduler>();
    
    			// start an STA thread and gets a task scheduler
    			_thread = new Thread(_ =>
    			{
    				// post the startup callback,
    				// it will be invoked when the message loop stars pumping
    				Dispatcher.CurrentDispatcher.InvokeAsync(
    					() => tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext()), 
    					DispatcherPriority.ApplicationIdle);
    				
    				// run the WPF Dispatcher message loop
    				Dispatcher.Run();
    			});
    
    			_thread.SetApartmentState(ApartmentState.STA);
    			_thread.IsBackground = true;
    			_thread.Start();
    			_taskScheduler = tcs.Task.Result;
    		}
    
    		// shutdown the STA thread
    		public void Dispose()
    		{
    			if (_taskScheduler != null)
    			{
    				var taskScheduler = _taskScheduler;
    				_taskScheduler = null;
    
    				if (_thread != null && _thread.IsAlive)
    				{
    					// execute Dispatcher.ExitAllFrames() on the STA thread
    					Task.Factory.StartNew(
    						() => Dispatcher.ExitAllFrames(),
    						CancellationToken.None,
    						TaskCreationOptions.None,
    						taskScheduler).Wait();
    
    					_thread.Join();
    				}
    				_thread = null;
    			}
    		}
    
    		// Task.Factory.StartNew wrappers
    		public void Invoke(Action action)
    		{
    			Task.Factory.StartNew(action,
    				CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
    		}
    
    		public TResult Invoke<TResult>(Func<TResult> func)
    		{
    			return Task.Factory.StartNew(func,
    				CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
    		}
    
    		public Task Run(Action action, CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    		}
    
    		public Task<TResult> Run<TResult>(Func<TResult> func, CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew(func, token, TaskCreationOptions.None, _taskScheduler);
    		}
    
    		public Task Run(Func<Task> func, CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew(func, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    		}
    
    		public Task<TResult> Run<TResult>(Func<Task<TResult>> func, CancellationToken token = default(CancellationToken))
    		{
    			return Task.Factory.StartNew(func, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    		}
    	}
    
    	/// <summary>
    	/// NativeMethods
    	/// </summary>
    	internal class NativeMethods
    	{
    		[DllImport("kernel32.dll", PreserveSig = true)]
    		public static extern uint GetCurrentThreadId();
    
    		[DllImport("user32.dll", PreserveSig = true)]
    		public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
    	}
    }
