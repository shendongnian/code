    public MainWindow()
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length == 1)
                {
                    MessageBox.Show("No argument provided");
                    Environment.Exit(0);
                }
                string arg1 = args[1];  // your argument
                InitializeComponent();
            }
