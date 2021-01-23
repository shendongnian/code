    using System.Runtime.InteropServices;
    
    string net_base = Path.GetFullPath(Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), @"..\.."));
    string strTemp32 = string.Concat(net_base, @"\Framework\", RuntimeEnvironment.GetSystemVersion(), @"\Temporary ASP.NET Files");
    string strTemp64 = string.Concat(net_base, @"\Framework64\", RuntimeEnvironment.GetSystemVersion(), @"\Temporary ASP.NET Files");
