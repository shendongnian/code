    class Program
        {
            static void Main(string[] args)
            {
                //Login loginObject = new Login();
    
                //int _loginTime = loginObject.login(); 
    
                int logintime = 5;
    
                Booking bookingObject = new Booking();
    
                bookingObject.booking(logintime);
    
                Thread t = new Thread(delegate() { bookingObject.booking(logintime); });
    
                t.Start();
    
                t.Join();
    
                //Console.ReadLine();
            }
        }
    
        class Booking
        {
            public void booking(int logintime)
            {
                DateTime _date; 
                int _route; 
                int _option; 
                string _pan; 
                
                try
                {
                    Console.WriteLine("Enter Date of journey(dd/mm/yyyy)");
                    string str = Console.ReadLine();
                    _date = Convert.ToDateTime(str);
    
                    
                    //_date = DateTime.Parse(str);
                    //Code here
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception Returns");
                }
            }
        }
