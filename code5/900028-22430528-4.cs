    namespace WpfApplication1
    {
        public partial class App : Application
        {
            App()
            {
                InitializeComponent();
            }
    
            [STAThread]
            static void Main(string args)
            {
    
                if (string.IsNullOrEmpty(args)) {
                    // Run your Main Form
                    // (blocks until Form1 is closed)
                    Window1 window = new Window1();
                    App app = new App();
                    app.Run(window);
                }
                else {
                    // Run the context menu action
                    fileCopytoDirA(args);
                }
    
                // exit
            }
    
            static void fileCopytoDirA(string args) {
                // this your part ;)
            }
        }
    }
