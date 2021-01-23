    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace CustomMarshaler
    {
        public class MyCustomMarshaler : ICustomMarshaler
        {
            private Dictionary<IntPtr, object> managedObjects = new Dictionary<IntPtr, object>();
    
            public IntPtr MarshalManagedToNative(object managedObj)
            {
                if (managedObj == null)
                    return IntPtr.Zero;
                if (!(managedObj is int[]))
                    throw new MarshalDirectiveException("MyCustomMarshaler must be used on an int array.");
    
                int[] arr = (int[])managedObj;
                int size = sizeof(int) + arr.Length * sizeof(int);
                IntPtr pNativeData = Marshal.AllocHGlobal(size);
                Marshal.WriteInt32(pNativeData, arr.Length);
                Marshal.Copy(arr, 0, pNativeData + sizeof(int), arr.Length);
    
                lock (managedObjects)
                {
                    managedObjects.Add(pNativeData, managedObj);
                }
    
                return pNativeData;
            }
    
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                int[] arr;
                lock (managedObjects)
                {
                    arr = (int[])managedObjects[pNativeData];
                    managedObjects.Remove(pNativeData);
                }
                int len = Marshal.ReadInt32(pNativeData);
                Debug.Assert(len == arr.Length);
                Marshal.Copy(pNativeData + sizeof(int), arr, 0, len);
                return arr;
            }
    
            public void CleanUpNativeData(IntPtr pNativeData)
            {
                Marshal.FreeHGlobal(pNativeData);
            }
    
            public void CleanUpManagedData(object managedObj)
            {
            }
    
            public int GetNativeDataSize()
            {
                return -1;
            }
    
            public static ICustomMarshaler GetInstance(string cookie)
            {
                return new MyCustomMarshaler();
            }
        }
    
        class Program
        {
            [DllImport(@"MyLib.dll")]
            private static extern void Foo(
                [In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(MyCustomMarshaler))]
                int[] arr
            );
    
            static void Main(string[] args)
            {
                int[] colorTable = new int[] { 1, 2, 3, 6, 12 };
                Foo(colorTable);
                foreach (int value in colorTable)
                    Console.WriteLine(value);
            }
        }
    }
