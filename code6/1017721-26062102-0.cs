    static AutoResetEvent are = null;
    
    static void Main(string[] args)
    {
        Booking bookingObject = new Booking();
        Console.WriteLine("First call to booking in Main");
        bookingObject.booking(100);
        new Thread(delegate()
        {
            Console.WriteLine("Thread starting");
            bookingObject.booking(100);
        }).Start();
        Console.WriteLine("Console.Readline in Main");
        // Comment these two lines to reproduce the original behavior
        are = new AutoResetEvent(false);
        are.WaitOne();
        string s = Console.ReadLine();
        Console.WriteLine("Result from main readline" + s);
    }
    
    class Booking
    {
       public void booking(int _loginTime)
       {
            DateTime _date;
            int _route;
            int _option;
            string _pan;
            try
            {
                Console.WriteLine("Enter Date of journey(dd/mm/yyyy)");
                string s = Console.ReadLine();
                Console.WriteLine(s);
                _date = Convert.ToDateTime(s);
                if(are != null) are.Set();
             }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date.");
            }
        }
    }
