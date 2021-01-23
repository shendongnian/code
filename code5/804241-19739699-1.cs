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
    			IntPtr _unkOuter;
    			IntPtr _unkInnerAggregated;
    			Inner _inner;
    
    			#region Inner
    			// Inner as aggregated object
    			class Inner :
    				ICustomQueryInterface,
    				IDisposable
    			{
    				object _outer;
    				Type[] _interfaces;
    
    				public Inner(object outer)
    				{
    					_outer = outer;
    					// the base's private COM interfaces are here
    					_interfaces = _outer.GetType().BaseType.GetInterfaces(); 
    				}
    
    				public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    				{
    					if (_outer != null)
    					{
    						var ifaceGuid = iid;
    						var iface = _interfaces.FirstOrDefault((t) => t.GUID == ifaceGuid);
    						if (iface != null)
    						{
    							var unk = Marshal.GetComInterfaceForObject(_outer, iface, CustomQueryInterfaceMode.Ignore);
    							if (unk != IntPtr.Zero)
    							{
    								ppv = unk;
    								return CustomQueryInterfaceResult.Handled;
    							}
    						}
    					}
    					ppv = IntPtr.Zero;
    					return CustomQueryInterfaceResult.Failed;
    				}
    
    				~Inner()
    				{
    					// need to work out the reference counting for GC to work correctly
    					Debug.Print("Inner object finalized.");
    				}
    
    				public void Dispose()
    				{
    					_outer = null;
    					_interfaces = null;
    				}
    			}
    			#endregion
    
    			// constructor
    			public ImprovedWebBrowserSite(WebBrowser host):
    				base(host)
    			{
    				// get the CCW object for this
    				_unkOuter = Marshal.GetIUnknownForObject(this);
    				Marshal.AddRef(_unkOuter);
    				try
    				{
    					// aggregate the CCW object with the helper Inner object
    					_inner = new Inner(this);
    					_unkInnerAggregated = Marshal.CreateAggregatedObject(_unkOuter, _inner);
    
    					// turn private WebBrowserSiteBase.IOleClientSite into our own IOleClientSite
    					_baseIOleClientSite = (IOleClientSite)Marshal.GetTypedObjectForIUnknown(_unkInnerAggregated, typeof(IOleClientSite));
    				}
    				finally
    				{
    					Marshal.Release(_unkOuter);
    				}
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
    
    				if (_unkOuter != IntPtr.Zero)
    				{
    					Marshal.Release(_unkOuter);
    					_unkOuter = IntPtr.Zero;
    				}
    			}
    
    			#region IOleClientSite
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
    			#endregion
    		}
    	}
    }
