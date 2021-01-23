    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleTest
    {
    	public static class ObjectGCEx
    	{
    		public static unsafe ObjContents *GetGCFields(this object obj)
    		{
    			return (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    		}
    		
    		/// <summary>
    		/// Gets private GC object's fields SyncBlockIndex and EEClass struct pointer
    		/// </summary>
    		public static unsafe void GetGCFields(this object obj, out UInt32 syncBlockIndex, out UInt32 eeClass)
    		{
    			var contents = (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    			syncBlockIndex = contents->syncBlockIndex;
    			eeClass = contents->eeClass;
    		}
    		
    					
    		/// <summary>
    		/// Gets private GC object's fields SyncBlockIndex and EEClass struct pointer
    		/// </summary>
    		public static unsafe UInt32 GetSyncBlockIndex(this object obj)
    		{
    			var contents = (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    			return contents->syncBlockIndex;
    		}
    					
    		/// <summary>
    		/// Gets private GC object's fields SyncBlockIndex and EEClass struct pointer
    		/// </summary>
    		public static unsafe UInt32 GetEEClass(this object obj)
    		{
    			var contents = (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    			return contents->eeClass;
    		}
    		
    		/// <summary>
    		/// Sets private GC object's field SyncBlockIndex, which is actually index in private GC table.
    		/// </summary>
    		/// <param name="obj">Object with SyncBlockIndex to be changed</param>
    		/// <param name="syncBlockIndex">New value of SyncBlockIndex</param>
    		public static unsafe void SetSyncBlockIndex(this object obj, UInt32 syncBlockIndex)
    		{
    			var contents = (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    			contents->syncBlockIndex = syncBlockIndex;
    		}
    					
    		/// <summary>
    		/// Sets private GC object's field EEClass, which is actually describes current class pointer
    		/// </summary>
    		/// <param name="obj">Object with SyncBlockIndex to be changed</param>
    		/// <param name="syncBlockIndex">New value of SyncBlockIndex</param>
    		public static unsafe void SetEEClass(this object obj, UInt32 eeClass)
    		{
    			var contents = (ObjContents*)((new ObjPointer { Object = obj }).Pointer);
    			contents->eeClass = eeClass;
    		}
    	}
    	
    	[StructLayout(LayoutKind.Explicit)]
    	public struct ObjPointer
    	{
    		[FieldOffset(0)]
    		internal object Object;
    		
    		[FieldOffset(4)]
    		internal uint _pointer;
    		
    		internal unsafe uint Pointer
    		{
    			get {
    				fixed(uint *pp = &_pointer)
    				{
    					return *(uint *)((uint)pp - sizeof(uint)) - sizeof(uint);
    				}
    			}
    		}
    	}
    
    	[StructLayout(LayoutKind.Explicit)]
    	public struct ObjContents
    	{
    		[FieldOffset(0)]
    		public UInt32 syncBlockIndex;
    
    		[FieldOffset(4)]
    		public UInt32 eeClass;
    
    		[FieldOffset(8)]
    		public byte fieldsStart;
    	}
    
    	public class MainClass		
    	{
    		public class Person
    		{
    			public int x = 123;
    
    			public override string ToString()
    			{
    				return "From Person";
    			}
    		}
    		
    		public class Customer
    		{
    			public override string ToString()
    			{
    				return "From Customer";
    			}
    		}
    		
    		public unsafe static void Main(string[] args)
    		{
    			var first = new Person();
    			var second = new Customer();
    			
    			unsafe
    			{
    				Console.WriteLine("type of first: {0}, ToString(): {1}", first.GetType().Name, first);
    				
    				first.SetEEClass(second.GetEEClass());
    				
    				Console.WriteLine("type of first: {0}, ToString(): {1}", first.GetType().Name, first);
    			}
    
    			Console.ReadKey();
    		}
    	}
    }
