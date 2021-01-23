    using System;
    using System.Runtime.InteropServices;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                // dynamic obj = Activator.CreateInstance(Type.GetTypeFromProgID("Noseratio.ManagedComObject"));
    
                dynamic obj = ComExt.CreateInstance(
                    Type.GetTypeFromProgID("Noseratio.ManagedComObject").GUID, 
                    localServer: true);
    
                Console.WriteLine(obj.ComMethod("hello"));
            }
        }
    
        // COM interop
        public static class ComExt
        {
            const uint CLSCTX_LOCAL_SERVER = 0x4;
            const uint CLSCTX_INPROC_SERVER = 0x1;
    
            static readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
    
            [DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
            static extern void CoCreateInstance(
               [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
               [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
               uint dwClsContext,
               [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
               [MarshalAs(UnmanagedType.Interface)] out object rReturnedComObject);
    
            public static object CreateInstance(Guid clsid, bool localServer)
            {
                object unk;
                CoCreateInstance(clsid, null, localServer ? CLSCTX_LOCAL_SERVER : CLSCTX_INPROC_SERVER, IID_IUnknown, out unk);
                return unk;
            }
        }
    }
