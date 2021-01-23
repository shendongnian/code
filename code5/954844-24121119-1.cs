    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            [ComVisible(true)]
            [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)] // late binding only
            public interface ITest
            {
                void Report(string step);
            }
    
            [ComVisible(true)]
            [ClassInterface(ClassInterfaceType.None)]
            [ComDefaultInterface(typeof(ITest))]
            public class ComObject: MarshalByRefObject, ITest
            {
                public void Report(string step)
                {
                    Program.Report(step);
                }
            }
    
            public static void Main(string[] args)
            {
                var obj = new ComObject();
                obj.Report("Object created.");
    
                System.AppDomain domain = System.AppDomain.CreateDomain("New domain");
    
                // via GCHandle
                var gcHandle = GCHandle.Alloc(obj);
                domain.SetData("gcCookie", GCHandle.ToIntPtr(gcHandle));
    
                // via COM GIT
                var git = (ComExt.IGlobalInterfaceTable)(Activator.CreateInstance(Type.GetTypeFromCLSID(ComExt.CLSID_StdGlobalInterfaceTable)));
                var comCookie = git.RegisterInterfaceInGlobal(obj, ComExt.IID_IUnknown);
                domain.SetData("comCookie", comCookie);
    
                // via COM CCW
                var unkCookie = Marshal.GetIUnknownForObject(obj);
                domain.SetData("unkCookie", unkCookie);
    
                // invoke in another domain
                domain.DoCallBack(() =>
                {
                    Program.Report("Another domain");
    
                    // trying GCHandle - fails
                    var gcCookie2 = (IntPtr)(System.AppDomain.CurrentDomain.GetData("gcCookie"));
                    var gcHandle2 = GCHandle.FromIntPtr(gcCookie2);
                    try
                    {
                        var gcObj2 = (ComObject)(gcHandle2.Target);
                        gcObj2.Report("via GCHandle");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
    
                    // trying COM GIT - works
                    var comCookie2 = (uint)(System.AppDomain.CurrentDomain.GetData("comCookie"));
                    var git2 = (ComExt.IGlobalInterfaceTable)(Activator.CreateInstance(Type.GetTypeFromCLSID(ComExt.CLSID_StdGlobalInterfaceTable)));
                    var obj2 = (ITest)git2.GetInterfaceFromGlobal(comCookie2, ComExt.IID_IUnknown);
                    obj2.Report("via GIT");
    
                    // trying COM CCW
                    var unkCookie2 = (IntPtr)(System.AppDomain.CurrentDomain.GetData("unkCookie"));
                    var unkObj2 = (ITest)Marshal.GetObjectForIUnknown(unkCookie2);
                    obj2.Report("via CCW");
                });
    
                Console.ReadLine();
            }
    
            static void Report(string step)
            {
                Console.WriteLine(new
                    {
                        step,
                        ctx = Thread.CurrentContext.GetHashCode(),
                        threadId = Thread.CurrentThread.ManagedThreadId,
                        domain = Thread.GetDomain().FriendlyName,
                    });
            }
    
            public static class ComExt
            {
                static public readonly Guid CLSID_StdGlobalInterfaceTable = new Guid("00000323-0000-0000-c000-000000000046");
                static public readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
    
                [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000146-0000-0000-C000-000000000046")]
                public interface IGlobalInterfaceTable
                {
                    uint RegisterInterfaceInGlobal(
                        [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
                        [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    
                    void RevokeInterfaceFromGlobal(uint dwCookie);
    
                    [return: MarshalAs(UnmanagedType.IUnknown)]
                    object GetInterfaceFromGlobal(
                        uint dwCookie,
                        [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
                }
            }
        }
    }
