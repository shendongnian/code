    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            class parResults 
            {
                private const int parScoreLen = 16;
                private const int parContractsStringLen = 128;
    
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * parScoreLen)]
                private byte[] parScoreBuff;
    
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * parContractsStringLen)]
                private byte[] parContractsStringBuff;
    
                public string getParScore(int index)
                {
                    string str = Encoding.Default.GetString(parScoreBuff, index * parScoreLen, parScoreLen);
                    int len = str.IndexOf('\0');
                    if (len != -1)
                        str = str.Substring(0, len);
                    return str;
                }
    
                public void setParScore(int index, string value)
                {
                    byte[] bytes = Encoding.Default.GetBytes(value);
                    int len = Math.Min(bytes.Length, parScoreLen);
                    Array.Copy(bytes, 0, parScoreBuff, index * parScoreLen, len);
                    Array.Clear(parScoreBuff, index * parScoreLen + len, parScoreLen - len);
                }
    
                public string parContractsString(int index)
                {
                    string str = Encoding.Default.GetString(parContractsStringBuff, index * parContractsStringLen, parContractsStringLen);
                    int len = str.IndexOf('\0');
                    if (len != -1)
                        str = str.Substring(0, len);
                    return str;
                }
    
                public void setParContractsString(int index, string value)
                {
                    byte[] bytes = Encoding.Default.GetBytes(value);
                    int len = Math.Min(bytes.Length, parContractsStringLen);
                    Array.Copy(bytes, 0, parContractsStringBuff, index * parContractsStringLen, len);
                    Array.Clear(parContractsStringBuff, index * parContractsStringLen + len, parContractsStringLen - len);
                }
    
                public parResults()
                {
                    parScoreBuff = new byte[32];
                    parContractsStringBuff = new byte[256];
                }
            };
    
            [DllImport(@"...", CallingConvention = CallingConvention.Cdecl)]
            static extern void foo([In,Out] parResults res);
    
            static void Main(string[] args)
            {
                parResults res = new parResults();
                res.setParContractsString(0, "foo");
                res.setParContractsString(1, "bar");
                foo(res);
                Console.WriteLine(res.getParScore(0));
                Console.WriteLine(res.getParScore(1));
                Console.ReadLine();
            }
        }
    }
