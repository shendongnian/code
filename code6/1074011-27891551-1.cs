    '''<summary>
    '''Application Entry Point.
    '''</summary>
    <System.STAThreadAttribute(),  _
     System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Shared Sub Main()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssembly
        Dim app As Application = New Application()
        app.InitializeComponent
        app.Run
    End Sub
