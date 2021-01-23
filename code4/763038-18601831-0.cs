         public InsertNames()
         {
           AllocConsole();
           InitializeComponent();
         }
    
          [System.Runtime.InteropServices.DllImport("kernel32.dll")]
          private static extern bool AllocConsole();
