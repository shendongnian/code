    private async void Form1_Load(object sender, EventArgs ev)
    {
        SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
        ie.Visible = true;
    
        var documentCompleteTcs = new TaskCompletionSource<bool>();
        ie.DocumentComplete += delegate
        {
            if (documentCompleteTcs.Task.IsCompleted)
                return;
            documentCompleteTcs.SetResult(true);
        };
    
        ie.Navigate("http://jsfiddle.net/");
        await documentCompleteTcs.Task;
    
        // inject __execScript code into the top window
        var execScriptCode = "(window.__execScript = function(exp) { return eval(exp); }, window.self)";
        var window = DispExInvoker.Invoke(ie.Document.parentWindow, "eval", execScriptCode);
    
        // inject __execScript into a child iframe
        var iframe = DispExInvoker.Invoke(window, "__execScript", 
            String.Format("document.all.tags('iframe')[0].contentWindow.eval('{0}')",  execScriptCode));
    
        // invoke 'alert(document.URL)' in the context of the child frame
        DispExInvoker.Invoke(iframe, "__execScript", "alert(document.URL)");
    }
    
    /// <summary>
    /// Managed wrapper for calling IDispatchEx::Invoke
    /// http://stackoverflow.com/a/18349546/1768303
    /// </summary>
    public class DispExInvoker
    {
        // check is the object supports IsDispatchEx
        public static bool IsDispatchEx(object target)
        {
            return (target as IDispatchEx) != null;
        }
    
        // invoke a method on the target IDispatchEx object
        public static object Invoke(object target, string method, params object[] args)
        {
            var dispEx = target as IDispatchEx;
            if (dispEx == null)
                throw new InvalidComObjectException();
    
            var dp = new System.Runtime.InteropServices.ComTypes.DISPPARAMS();
            try
            {
                // repack arguments
                if (args.Length > 0)
                {
                    // should be using stackalloc for DISPPARAMS arguments, but don't want enforce "/unsafe"
                    int size = SIZE_OF_VARIANT * args.Length;
                    dp.rgvarg = Marshal.AllocCoTaskMem(size);
                    ZeroMemory(dp.rgvarg, size); // zero'ing is equal to VariantInit
                    dp.cArgs = args.Length;
                    for (int i = 0; i < dp.cArgs; i++)
                        Marshal.GetNativeVariantForObject(args[i], dp.rgvarg + SIZE_OF_VARIANT * (args.Length - i - 1));
                }
    
                int dispid;
                dispEx.GetDispID(method, fdexNameCaseSensitive, out dispid);
    
                var ei = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
                var result = Type.Missing;
                dispEx.InvokeEx(dispid, 0, DISPATCH_METHOD, ref dp, ref result, ref ei, null);
                return result;
            }
            finally
            {
                if (dp.rgvarg != IntPtr.Zero)
                {
                    for (var i = 0; i < dp.cArgs; i++)
                        VariantClear(dp.rgvarg + SIZE_OF_VARIANT * i);
                    Marshal.FreeCoTaskMem(dp.rgvarg);
                }
            }
        }
    
        // interop declarations
    
        [DllImport("oleaut32.dll", PreserveSig = false)]
        static extern void VariantClear(IntPtr pvarg);
        [DllImport("Kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
        static extern void ZeroMemory(IntPtr dest, int size);
    
        const uint fdexNameCaseSensitive = 0x00000001;
        const ushort DISPATCH_METHOD = 1;
        const int SIZE_OF_VARIANT = 16;
    
        // IDispatchEx interface
    
        [ComImport()]
        [Guid("A6EF9860-C720-11D0-9337-00A0C90DCAA9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IDispatchEx
        {
            // IDispatch
            int GetTypeInfoCount();
            [return: MarshalAs(UnmanagedType.Interface)]
            System.Runtime.InteropServices.ComTypes.ITypeInfo GetTypeInfo([In, MarshalAs(UnmanagedType.U4)] int iTInfo, [In, MarshalAs(UnmanagedType.U4)] int lcid);
            void GetIDsOfNames([In] ref Guid riid, [In, MarshalAs(UnmanagedType.LPArray)] string[] rgszNames, [In, MarshalAs(UnmanagedType.U4)] int cNames, [In, MarshalAs(UnmanagedType.U4)] int lcid, [Out, MarshalAs(UnmanagedType.LPArray)] int[] rgDispId);
            void Invoke(int dispIdMember, ref Guid riid, uint lcid, ushort wFlags, ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams, out object pVarResult, ref System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo, IntPtr[] pArgErr);
    
            // IDispatchEx
            void GetDispID([MarshalAs(UnmanagedType.BStr)] string bstrName, uint grfdex, [Out] out int pid);
            void InvokeEx(int id, uint lcid, ushort wFlags,
                [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pdp,
                [In, Out] ref object pvarRes,
                [In, Out] ref System.Runtime.InteropServices.ComTypes.EXCEPINFO pei,
                System.IServiceProvider pspCaller);
            void DeleteMemberByName([MarshalAs(UnmanagedType.BStr)] string bstrName, uint grfdex);
            void DeleteMemberByDispID(int id);
            void GetMemberProperties(int id, uint grfdexFetch, [Out] out uint pgrfdex);
            void GetMemberName(int id, [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.I4)]
            int GetNextDispID(uint grfdex, int id, [In, Out] ref int pid);
            void GetNameSpaceParent([Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
        }
    }
