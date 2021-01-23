    [STAThread]
    static void Main() {    
       AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolverHelper.AssemblyResolveHandler;
       MainSub();
    }
    
    // MainSub() is here to avoids that the Main() method uses something
    // from NDepend.API without having registered AssemblyResolveHandler
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void MainSub() {
       ...
