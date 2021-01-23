         public Form1()
         {
           AllocConsole();
           InitializeComponent();
         }
    
          [System.Runtime.InteropServices.DllImport("kernel32.dll")]
          private static extern bool AllocConsole();
        void PrintMethod()
        {
          Console.WriteLine("Occurence :"+count.ToString());
        }
