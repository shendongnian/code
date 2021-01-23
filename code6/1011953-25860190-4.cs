    public partial class App : Application
    {
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main(string[] args)
        {
            MainWindow window = new MainWindow(args != null && args.Length > 0 ? args[0] : "");
            window.ShowDialog();
        }
    }
