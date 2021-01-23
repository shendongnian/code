    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //How to ensure that you'll get your message
            var myForm = new Form1();
            myForm.myEvent += myForm_myEvent;
            Application.Run(new Form1());
        }
        //What to do once you get your Message
        static void myForm_myEvent(object sender, EventArgs e)
        {
            var myEventArgs = (MyEventArgs)e;
            Console.WriteLine(myEventArgs.Message);
        }
    }
