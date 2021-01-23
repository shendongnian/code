    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace CustomWebBrowser
    {
    	public partial class MainForm : Form
    	{
    		public MainForm()
    		{
    			InitializeComponent();
    		}
    
    		private void MainForm_Load(object sender, EventArgs e)
    		{
    			var wb = new ImprovedWebBrowser();
    			wb.Dock = DockStyle.Fill;
    			this.Controls.Add(wb);
    			wb.Visible = true;
    			wb.DocumentText = "<b>Hello from ImprovedWebBrowser!</b>";
    		}
    	}
    
    	// ImprovedWebBrowser with custom pass-through IOleClientSite 
    	public class ImprovedWebBrowser: WebBrowser
    	{
    		// provide custom WebBrowserSite,
    		// where we override IOleClientSite and call the base implementation
    		protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
    		{
    			return new ImprovedWebBrowserSite(this);
    		}
    
    		// IOleClientSite
    		[ComImport(), Guid("00000118-0000-0000-C000-000000000046")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		public interface IOleClientSite
    		{
    			void SaveObject();
    
    			[return: MarshalAs(UnmanagedType.Interface)]
    			object GetMoniker(
    				[In, MarshalAs(UnmanagedType.U4)] int dwAssign,
    				[In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker);
    
    			[PreserveSig]
    			int GetContainer([Out] out IntPtr ppContainer);
    
    			void ShowObject();
    
    			void OnShowWindow([In, MarshalAs(UnmanagedType.I4)] int fShow);
    
    			void RequestNewObjectLayout();
    		}
    
    		// ImprovedWebBrowserSite
    		protected class ImprovedWebBrowserSite :
    			WebBrowserSite,
    			IOleClientSite,
    			ICustomQueryInterface,
    			IDisposable
    		{
    			IOleClientSite _baseIOleClientSite;
    			IntPtr _unkBaseIOleClientSite;
    			IntPtr _unkInnerAggregated;
    			Inner _inner;
    
    			// Inner as aggregated object
    			class Inner :
    				ICustomQueryInterface,
    				IDisposable
    			{
    				IntPtr _unkOuter;
    
    				public Inner(IntPtr unkOuter)
    				{
    					_unkOuter = unkOuter; // do not AddRef
    				}
    
    				public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    				{
    					if (iid == typeof(IOleClientSite).GUID && _unkOuter != IntPtr.Zero)
    					{
    						ppv = _unkOuter;
    						return CustomQueryInterfaceResult.Handled;
    					}
    					ppv = IntPtr.Zero;
    					return CustomQueryInterfaceResult.Failed;
    				}
    
    				~Inner()
    				{
    					// need to work out the reference counting for GC to work correctly
    					Debug.Print("ImprovedWebBrowserSite.Inner finalized.");
    				}
    
    				public void Dispose()
    				{
    					_unkOuter = IntPtr.Zero;
    				}
    			}
    
    			// constructor
    			public ImprovedWebBrowserSite(WebBrowser host):
    				base(host)
    			{
    				// get WebBrowserSiteBase.IOleClientSite via reflection
    				var typeBaseIOleClientSite = typeof(WebBrowserSiteBase).GetInterfaces().First((t) =>
    					t.GUID == typeof(IOleClientSite).GUID);
    
    				// get the COM interface for WebBrowserSiteBase.IOleClientSite
    				_unkBaseIOleClientSite = Marshal.GetComInterfaceForObject(this, typeBaseIOleClientSite, CustomQueryInterfaceMode.Ignore);
    				Marshal.AddRef(_unkBaseIOleClientSite); // protect _unkBaseIOleClientSite
    
    				// aggregate it with the helper Inner object
    				_inner = new Inner(_unkBaseIOleClientSite);
    				_unkInnerAggregated = Marshal.CreateAggregatedObject(_unkBaseIOleClientSite, _inner);
    
    				// turn private WebBrowserSiteBase.IOleClientSite into our own IOleClientSite
    				_baseIOleClientSite = (IOleClientSite)Marshal.GetTypedObjectForIUnknown(_unkInnerAggregated, typeof(IOleClientSite));
    
    				Marshal.Release(_unkBaseIOleClientSite);
    			}
    
    			~ImprovedWebBrowserSite()
    			{
    				// need to work out the reference counting for GC to work correctly
    				Debug.Print("ImprovedClass finalized.");
    			}
    
    			public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    			{
    				if (iid == typeof(IOleClientSite).GUID)
    				{
    					// CustomQueryInterfaceMode.Ignore is to avoid infinite loop during QI.
    					ppv = Marshal.GetComInterfaceForObject(this, typeof(IOleClientSite), CustomQueryInterfaceMode.Ignore);
    					return CustomQueryInterfaceResult.Handled;
    				}
    				ppv = IntPtr.Zero;
    				return CustomQueryInterfaceResult.NotHandled;
    			}
    
    			void IDisposable.Dispose()
    			{
    				base.Dispose();
    
    				// we may have recicular references to itself
    				_baseIOleClientSite = null;
    
    				if (_inner != null)
    				{
    					_inner.Dispose();
    					_inner = null;
    				}
    
    				if (_unkInnerAggregated != IntPtr.Zero)
    				{
    					Marshal.Release(_unkInnerAggregated);
    					_unkInnerAggregated = IntPtr.Zero;
    				}
    
    				if (_unkBaseIOleClientSite != IntPtr.Zero)
    				{
    					Marshal.Release(_unkBaseIOleClientSite);
    					_unkBaseIOleClientSite = IntPtr.Zero;
    				}
    			}
    
    			// IOleClientSite
    			public void SaveObject()
    			{
    				Debug.Print("IOleClientSite.SaveObject");
    				_baseIOleClientSite.SaveObject();
    			}
    
    			public object GetMoniker(int dwAssign, int dwWhichMoniker)
    			{
    				Debug.Print("IOleClientSite.GetMoniker");
    				return _baseIOleClientSite.GetMoniker(dwAssign, dwWhichMoniker);
    			}
    
    			public int GetContainer(out IntPtr ppContainer)
    			{
    				Debug.Print("IOleClientSite.GetContainer");
    				return _baseIOleClientSite.GetContainer(out ppContainer);
    			}
    
    			public void ShowObject()
    			{
    				Debug.Print("IOleClientSite.ShowObject");
    				_baseIOleClientSite.ShowObject();
    			}
    
    			public void OnShowWindow(int fShow)
    			{
    				Debug.Print("IOleClientSite.OnShowWindow");
    				_baseIOleClientSite.OnShowWindow(fShow);
    			}
    
    			public void RequestNewObjectLayout()
    			{
    				Debug.Print("IOleClientSite.RequestNewObjectLayout");
    				_baseIOleClientSite.RequestNewObjectLayout();
    			}
    		}
    	}
    }
