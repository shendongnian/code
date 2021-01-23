    static System.Windows.Forms.Timer testtimer = new System.Windows.Forms.Timer();
    
        static void Main()
        {
            testtimer.Tick += testtimertick;
            testtimer.Interval = 5000;
            testtimer.Enabled = true;
           
            while (true)
            {
                Application.DoEvents();  //Prevents application from exiting
            }
    
        }
    
     private static void testtimertick(object sender, System.EventArgs e)
        { 
                 
                Thread t = new Thread(dostuff);
                t.Start();
        }
    
    
    private static void dostuff()
        {
           testtimer.Enabled = false;
           //Executes some code
           testtimer.Enabled = true; //Re enables the timer but it doesn't work
           testtimer.Start();
         }
