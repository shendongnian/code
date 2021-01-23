     [STAThread]
     static void Main()
     {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         using (var myApplicationContext = new MyApplicationContext(new Form1()))
         {
            Application.Run(myApplicationContext);
         }
     }
