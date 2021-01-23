    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace ManagedServer
    {
    	/*
    	// IComInterface IDL definition
    	[
    		uuid(9AD16CCE-7588-486C-BC56-F3161FF92EF2),
    		oleautomation
    	]
    	interface IComInterface: IUnknown
    	{
    		HRESULT ComMethod(IUnknown* arg);
    	}
    	*/
    
    	// OldLibrary
    	public static class OldLibrary
    	{
    		// private COM interface IComInterface
    		[ComImport(), Guid("9AD16CCE-7588-486C-BC56-F3161FF92EF2")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		private interface IComInterface
    		{
    			void ComMethod([In, MarshalAs(UnmanagedType.Interface)] object arg);
    		}
    
    		[ComVisible(true)]
    		[ClassInterface(ClassInterfaceType.None)]
    		public class BaseClass : IComInterface
    		{
    			void IComInterface.ComMethod(object arg)
    			{
    				Console.WriteLine("BaseClass.IComInterface.ComMethod");
    			}
    		}
    	}
    
    	// NewLibrary 
    	public static class NewLibrary
    	{
    		// OldLibrary.IComInterface is inaccessible here,
    		// define a new equivalent version
    		[ComImport(), Guid("9AD16CCE-7588-486C-BC56-F3161FF92EF2")]
    		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    		private interface IComInterface
    		{
    			void ComMethod([In, MarshalAs(UnmanagedType.Interface)] object arg);
    		}
    
    		[ComVisible(true)]
    		[ClassInterface(ClassInterfaceType.None)]
    		public class ImprovedClass :
    			OldLibrary.BaseClass,
    			NewLibrary.IComInterface,
    			ICustomQueryInterface,
    			IDisposable
    		{
    			NewLibrary.IComInterface _baseIComInterface;
    			BaseClassComProxy _baseClassComProxy;
    
    			// IComInterface
    			// we want to call BaseClass.IComInterface.ComMethod which is only accessible via COM
    			void IComInterface.ComMethod(object arg)
    			{
    				_baseIComInterface.ComMethod(arg);
    				Console.WriteLine("ImprovedClass.IComInterface.ComMethod");
    			}
    
    			// ICustomQueryInterface
    			public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    			{
    				if (iid == typeof(NewLibrary.IComInterface).GUID)
    				{
    					// CustomQueryInterfaceMode.Ignore is to avoid infinite loop during QI.
    					ppv = Marshal.GetComInterfaceForObject(this, typeof(NewLibrary.IComInterface), CustomQueryInterfaceMode.Ignore);
    					return CustomQueryInterfaceResult.Handled;
    				}
    				ppv = IntPtr.Zero;
    				return CustomQueryInterfaceResult.NotHandled;
    			}
    
    			// constructor
    			public ImprovedClass()
    			{
    				// aggregate the CCW object with the helper Inner object
    				_baseClassComProxy = new BaseClassComProxy(this);
    				_baseIComInterface = _baseClassComProxy.GetComInterface<IComInterface>();	
    			}
    
    			~ImprovedClass()
    			{
    				Dispose();
    				Console.WriteLine("ImprovedClass finalized.");
    			}
    
    			// IDispose
    			public void Dispose()
    			{
    				// we may have recicular COM references to itself
    				// e.g., via _baseIComInterface
    				// make sure to release all references
    
    				if (_baseIComInterface != null)
    				{
    					Marshal.ReleaseComObject(_baseIComInterface);
    					_baseIComInterface = null;
    				}
    
    				if (_baseClassComProxy != null)
    				{
    					_baseClassComProxy.Dispose();
    					_baseClassComProxy = null;
    				}
    			}
    
    			// for testing
    			public void InvokeComMethod()
    			{
    				((NewLibrary.IComInterface)this).ComMethod(null);
    			}
    		}
    
    		#region BaseClassComProxy
    		// Inner as aggregated object
    		class BaseClassComProxy :
    			ICustomQueryInterface,
    			IDisposable
    		{
    			WeakReference _outer; // avoid circular refs between outer and inner object
    			Type[] _interfaces; // the base's private COM interfaces are here
    			IntPtr _unkAggregated; // aggregated proxy
    
    			public BaseClassComProxy(object outer)
    			{
    				_outer = new WeakReference(outer);
    				_interfaces = outer.GetType().BaseType.GetInterfaces();
    				var unkOuter = Marshal.GetIUnknownForObject(outer);
    				try
    				{
    					// CreateAggregatedObject does AddRef on this 
    					// se we provide IDispose for proper shutdown
    					_unkAggregated = Marshal.CreateAggregatedObject(unkOuter, this); 
    				}
    				finally
    				{
    					Marshal.Release(unkOuter);
    				}
    			}
    
    			public T GetComInterface<T>() where T : class
    			{
    				// cast an outer's base interface to an equivalent outer's interface
    				return (T)Marshal.GetTypedObjectForIUnknown(_unkAggregated, typeof(T));
    			}
    
    			public void GetComInterface<T>(out T baseInterface) where T : class
    			{
    				baseInterface = GetComInterface<T>();
    			}
    
    			~BaseClassComProxy()
    			{
    				Dispose();
    				Console.WriteLine("BaseClassComProxy object finalized.");
    			}
    
    			// IDispose
    			public void Dispose()
    			{
    				if (_outer != null)
    				{
    					_outer = null;
    					_interfaces = null;
    					if (_unkAggregated != IntPtr.Zero)
    					{
    						Marshal.Release(_unkAggregated);
    						_unkAggregated = IntPtr.Zero;
    					}
    				}
    			}
    
    			// ICustomQueryInterface
    			public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    			{
    				// access to the outer's base private COM interfaces
    				if (_outer != null)
    				{
    					var ifaceGuid = iid;
    					var iface = _interfaces.FirstOrDefault((i) => i.GUID == ifaceGuid);
    					if (iface != null && iface.IsImport)
    					{
    						// must be a COM interface with ComImport attribute
    						var unk = Marshal.GetComInterfaceForObject(_outer.Target, iface, CustomQueryInterfaceMode.Ignore);
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
    		}
    		#endregion
    
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// test
    			var improved = new NewLibrary.ImprovedClass();
    			improved.InvokeComMethod(); 
    
    			//// COM client
    			//var unmanagedObject = (ISimpleUnmanagedObject)Activator.CreateInstance(Type.GetTypeFromProgID("Noseratio.SimpleUnmanagedObject"));
    			//unmanagedObject.InvokeComMethod(improved);
    
    			improved.Dispose();
    			improved = null;
    
    			// test ref counting
    			GC.Collect(generation: GC.MaxGeneration, mode: GCCollectionMode.Forced, blocking: false);
    			Console.WriteLine("Press Enter to exit.");
    			Console.ReadLine();
    		}
    
    		// COM test client interfaces
    		[ComImport(), Guid("2EA68065-8890-4F69-A02F-2BC3F0418561")]
    		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
    		internal interface ISimpleUnmanagedObject
    		{
    			void InvokeComMethod([In, MarshalAs(UnmanagedType.Interface)] object arg);
    			void InvokeComMethodDirect([In] IntPtr comInterface);
    		}
    
    	}
    }
