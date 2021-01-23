    using System;
    using System.Runtime.InteropServices;
    
    namespace Library1
    {
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("4C08A691-5D61-4E9A-B16D-75BAD2834BAE")]
        public interface Interface
        {
            void TestMethod();
        }
    
        [ComVisible(true)]
        public class Server : Interface
        {
            public Server() { }
    
            public void TestMethod()
            {
                Console.WriteLine("TestMethod called");
            }
        }
    }
    
    namespace Library2
    {
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("4C08A691-5D61-4E9A-B16D-75BAD2834BAE")]
        public interface Interface
        {
            void TestMethod();
        }
    
        public class Client
        {
            public void CallMethod(Library2.Interface server)
            {
                server.TestMethod();
            }
        }
    }
    
    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // convert Library1.Server to Library2.Interface 
                var server = ComWrapper.Create<Library2.Interface>(() => new Library1.Server());
                var client = new Library2.Client();
                client.CallMethod(server);
    
                Marshal.ReleaseComObject(server);
                Console.ReadLine();
            }
        }
    
        /// <summary>
        /// ComWrapper - http://stackoverflow.com/q/26758316/1768303
        /// by Noseratio
        /// </summary>
        public class ComWrapper
        {
            readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
            const int S_OK = 0;
            const int E_FAIL = unchecked((int)0x80004005);
    
            delegate int QueryInterfaceMethod(IntPtr pUnk, ref Guid iid, out IntPtr ppv);
            delegate int AddRefMethod(IntPtr pUnk);
            delegate int ReleaseMethod(IntPtr pUnk);
    
            [StructLayout(LayoutKind.Sequential)]
            struct UnkObject
            {
                public IntPtr pVtable;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct UnkVtable
            {
                public IntPtr pQueryInterface;
                public IntPtr pAddRef;
                public IntPtr pRelease;
            }
    
            int _refCount = 0;
            IntPtr _pVtable;
            IntPtr _outerObject;
            IntPtr _aggregatedObject;
            GCHandle _gcHandle;
    
            QueryInterfaceMethod _queryInterfaceMethod;
            AddRefMethod _addRefMethod;
            ReleaseMethod _releaseMethod;
    
            private ComWrapper()
            {
            }
    
            ~ComWrapper()
            {
                Console.WriteLine("~ComWrapper");
                Free();
            }
    
            private IntPtr Initialize(Func<object> createInnerObject)
            {
                try
                {
                    // implement IUnknown methods
                    _queryInterfaceMethod = delegate(IntPtr pUnk, ref Guid iid, out IntPtr ppv)
                    {
                        lock (this)
                        {
                            // delegate anything but IID_IUnknown to the aggregated object
                            if (IID_IUnknown == iid)
                            {
                                ppv = _outerObject;
                                Marshal.AddRef(_outerObject);
                                return S_OK;
                            }
                            return Marshal.QueryInterface(_aggregatedObject, ref iid, out ppv);
                        }
                    };
    
                    _addRefMethod = delegate(IntPtr pUnk)
                    {
                        lock (this)
                        {
                            return ++_refCount;
                        }
                    };
    
                    _releaseMethod = delegate(IntPtr pUnk)
                    {
                        lock (this)
                        {
                            if (0 == --_refCount)
                            {
                                Free();
                            }
                            return _refCount;
                        }
                    };
    
                    // create the IUnknown vtable
                    var vtable = new UnkVtable();
                    vtable.pQueryInterface = Marshal.GetFunctionPointerForDelegate(_queryInterfaceMethod);
                    vtable.pAddRef = Marshal.GetFunctionPointerForDelegate(_addRefMethod);
                    vtable.pRelease = Marshal.GetFunctionPointerForDelegate(_releaseMethod);
    
                    _pVtable = Marshal.AllocCoTaskMem(Marshal.SizeOf(vtable));
                    Marshal.StructureToPtr(vtable, _pVtable, false);
    
                    // create the IUnknown object
                    var unkObject = new UnkObject();
                    unkObject.pVtable = _pVtable;
                    _outerObject = Marshal.AllocCoTaskMem(Marshal.SizeOf(unkObject));
                    Marshal.StructureToPtr(unkObject, _outerObject, false);
    
                    // pin the managed ComWrapper instance
                    _gcHandle = GCHandle.Alloc(this, GCHandleType.Normal);
    
                    // create and aggregate the inner object
                    _aggregatedObject = Marshal.CreateAggregatedObject(_outerObject, createInnerObject());
    
                    return _outerObject;
                }
                catch
                {
                    Free();
                    throw;
                }
            }
    
            private void Free()
            {
                Console.WriteLine("Free");
                if (_aggregatedObject != IntPtr.Zero)
                {
                    Marshal.Release(_aggregatedObject);
                    _aggregatedObject = IntPtr.Zero;
                }
                if (_pVtable != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(_pVtable);
                    _pVtable = IntPtr.Zero;
                }
                if (_outerObject != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(_outerObject);
                    _outerObject = IntPtr.Zero;
                }
                if (_gcHandle.IsAllocated)
                {
                    _gcHandle.Free();
                }
            }
    
            public static T Create<T>(Func<object> createInnerObject)
            {
                var wrapper = new ComWrapper();
                var unk = wrapper.Initialize(createInnerObject);
                Marshal.AddRef(unk);
                try
                {
                    var comObject = Marshal.GetObjectForIUnknown(unk);
                    return (T)comObject;
                }
                finally
                {
                    Marshal.Release(unk);
                }
            }
        }
    }
