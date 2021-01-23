    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace ManagedServer
    {
    	/*
    		[
    			uuid(9AD16CCE-7588-486C-BC56-F3161FF92EF2),
    			oleautomation
    		]
    		interface IComInterface: IUnknown
    		{
    			HRESULT ComMethod(IUnknown* arg);
    		}
    	*/
    
    	// OldLibrary Assembly
    	public static class OldLibrary
    	{
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
    
    	// NewLibrary Assembly 
    	public static class NewLibrary
    	{
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
    			IntPtr _unkBaseIComInterface;
    			IntPtr _unkInnerAggregated;
    			Inner _inner;
    
    			// we want to call BaseClass.IComInterface.ComMethod which is only accessible via COM
    			void IComInterface.ComMethod(object arg)
    			{
    				_baseIComInterface.ComMethod(arg);
    				Console.WriteLine("ImprovedClass.IComInterface.ComMethod");
    			}
    
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
    				// get OldLibrary.BaseClass.IComInterface via reflection
    				var typeBaseIComInterface = typeof(OldLibrary.BaseClass).GetInterfaces().First((t) =>
    					t.GUID == typeof(NewLibrary.IComInterface).GUID);
    
    				// get the COM interface for OldLibrary.BaseClass.IComInterface
    				_unkBaseIComInterface = Marshal.GetComInterfaceForObject(this, typeBaseIComInterface, CustomQueryInterfaceMode.Ignore);
    				Marshal.AddRef(_unkBaseIComInterface); // protect _unkBaseIComInterface
    
    				// aggregate it with a helper Inner object
    				_inner = new Inner(_unkBaseIComInterface);
    				_unkInnerAggregated = Marshal.CreateAggregatedObject(_unkBaseIComInterface, _inner);
    
    				// turn private OldLibrary.BaseClass.IComInterface into NewLibrary.IComInterface
    				_baseIComInterface = (IComInterface)Marshal.GetTypedObjectForIUnknown(_unkInnerAggregated, typeof(NewLibrary.IComInterface));
    	
    				Marshal.Release(_unkBaseIComInterface);
    			}
    
    			~ImprovedClass()
    			{
    				// need to work out the reference counting for GC to work correctly
    				Console.WriteLine("ImprovedClass finalized.");
    			}
    
    			public void Dispose()
    			{
    				// we may have recicular references to itself
    				_baseIComInterface = null;
    
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
    
    				if (_unkBaseIComInterface != IntPtr.Zero)
    				{
    					Marshal.Release(_unkBaseIComInterface);
    					_unkBaseIComInterface = IntPtr.Zero;
    				}
    			}
    
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
    					if (iid == typeof(IComInterface).GUID)
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
    					Console.WriteLine("ImprovedClass.Inner finalized.");
    				}
    
    				public void Dispose()
    				{
    					_unkOuter = IntPtr.Zero;
    				}
    			}
    
    			// for testing
    			public void InvokeComMethod()
    			{
    				((NewLibrary.IComInterface)this).ComMethod(null);
    			}
    		}
    	}
    
    	class Program
    	{
    		[ComImport(), Guid("2EA68065-8890-4F69-A02F-2BC3F0418561")]
    		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
    		internal interface ISimpleUnmanagedObject
    		{
    			void InvokeComMethod([In, MarshalAs(UnmanagedType.Interface)] object arg);
    			void InvokeComMethodDirect([In] IntPtr comInterface);
    		}
    
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
    
    			// need to work out the reference counting for GC to work correctly
    			GC.Collect();
    
    			Console.WriteLine("Press Enter to exit.");
    			Console.ReadLine();
    		}
    	}
    }
