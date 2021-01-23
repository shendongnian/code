    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace ManagedClient
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
    
    	// Assembly OldLibrary
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
    
    	// Assembly NewLibrary
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
    			IComInterface,
    			ICustomQueryInterface
    		{
    			IComInterface baseComInterface;
    
    			void IComInterface.ComMethod(object arg)
    			{
    				baseComInterface.ComMethod(arg);
    				Console.WriteLine("ImprovedClass.IComInterface.ComMethod");
    			}
    
    			public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    			{
    				if (iid == typeof(IComInterface).GUID)
    				{
    					// CustomQueryInterfaceMode.Ignore is to avoid infinite loop during QI.
    					ppv = Marshal.GetComInterfaceForObject(this, typeof(IComInterface), CustomQueryInterfaceMode.Ignore);
    					return CustomQueryInterfaceResult.Handled;
    				}
    				ppv = IntPtr.Zero;
    				return CustomQueryInterfaceResult.NotHandled;
    			}
    
    
    			public IntPtr unkBaseIComInterface;
    			public IntPtr unkBaseShim;
    
    			public ImprovedClass()
    			{
    				var typeBaseIComInterface = typeof(OldLibrary.BaseClass).GetInterfaces().First((t) =>
    					t.GUID == typeof(IComInterface).GUID); // get OldLibrary.BaseClass.IComInterface
    				this.unkBaseIComInterface = Marshal.GetComInterfaceForObject(this, typeBaseIComInterface, CustomQueryInterfaceMode.Ignore);
    
    				this.unkBaseShim = Marshal.CreateAggregatedObject(this.unkBaseIComInterface, new Inner(this.unkBaseIComInterface));
    				this.baseComInterface = (IComInterface)Marshal.GetTypedObjectForIUnknown(this.unkBaseShim, typeof(IComInterface));
    
    				((IComInterface)this).ComMethod(this); // works!
    			}
    
    			~ImprovedClass()
    			{
    				// still need to work out the reference counting for GC to work correctly
    				Marshal.Release(this.unkBaseIComInterface);
    				Marshal.Release(this.unkBaseShim);
    				Debug.Print("ImprovedClass finalized.");
    			}
    
    			class Inner : ICustomQueryInterface
    			{
    				IntPtr unkOuter;
    
    				public Inner(IntPtr unkOuter)
    				{
    					this.unkOuter = unkOuter; // do not AddRef
    				}
    
    				public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
    				{
    					if (iid == typeof(IComInterface).GUID)
    					{
    						ppv = this.unkOuter;
    						return CustomQueryInterfaceResult.Handled;
    					}
    					ppv = IntPtr.Zero;
    					return CustomQueryInterfaceResult.Failed;
    				}
    
    				~Inner()
    				{
    					// still need to work out the reference counting for GC to work correctly
    					Debug.Print("ImprovedClass.Inner finalized.");
    				}
    
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
    			var improved = new NewLibrary.ImprovedClass();
    			//// COM client
    			//var unmanagedObject = (ISimpleUnmanagedObject)Activator.CreateInstance(Type.GetTypeFromProgID("Noseratio.SimpleUnmanagedObject"));
    			//unmanagedObject.InvokeComMethod(improved);
    			Console.WriteLine("Press Enter to exit.");
    			Console.ReadLine();
    		}
    	}
    }
