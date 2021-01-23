    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const string dllname = @"...";
    
            [StructLayout(LayoutKind.Sequential)]
            public struct SERVICE_DATA
            {
                [MarshalAs(UnmanagedType.BStr)]
                public string DBALias;
    
                [MarshalAs(UnmanagedType.BStr)]
                public string LicKey;
    
                [MarshalAs(UnmanagedType.BStr)]
                public string Pass;
            }
    
            [DllImport(dllname, CallingConvention = CallingConvention.StdCall)]
            public static extern byte CreateRole(
                [In] ref SERVICE_DATA data,
                [MarshalAs(UnmanagedType.BStr)] out string str
            ); 
    
            static void Main(string[] args)
            {
                SERVICE_DATA data;
                data.DBALias = "DBALias";
                data.LicKey = "LicKey";
                data.Pass = "Pass";
                string str;
                var result = CreateRole(ref data, out str);
                Console.WriteLine(result);
                Console.WriteLine(str);
            }
        }
    }
