    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    
        [STAThread]
        static void Main()
        {
            //Thread l'affichage de la form
            Program SecondThread = new Program();
            Thread th = new Thread(new ThreadStart(SecondThread.ThreadForm));
            th.Start();  
    
            //Update the label1 text
            while (SecondThread.TheForm == null) 
            {
              Thread.Sleep(1);
            } 
            SecondThread.TheForm.SetTextLabel("foo");
    
        }
    
        internal Form1 TheForm {get; private set; }
    
        public void ThreadForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form1 = new Form1();
            Application.Run(form1);
            TheForm = form1;
    
        }
    
    }
