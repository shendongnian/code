     static void Main(string[] args)
                {
                    string dateString = "1/27/2014 1:37 PM";
                    string format = "MM/dd/yyyy HH:mm";
                  
        
                    DateTime dt2 = Convert.ToDateTime(dateString);
                   
                    Console.WriteLine(dt2.ToString(format));
                    Console.ReadLine();
                }
