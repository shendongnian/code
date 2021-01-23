       static void Main(string[] args)
        {
            string year, month, day = string.Empty;
            Console.WriteLine("Enter your Birthdate:");
            Console.WriteLine("Year :");
            year = Console.ReadLine();
            Console.WriteLine("Month :");
             month = Console.ReadLine();
            Console.WriteLine("Day :" );
            day = Console.ReadLine();
            try
            {
                DateTime date = Convert.ToDateTime(year + "-" + month + "-" + day);
                 var bday = float.Parse(date.ToString("yyyy.MMdd"));
                 var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                 if (now < bday)
                 {
                     Console.WriteLine("Invalid Input of date");
                     Console.ReadLine();
                    
                 }
                 string age = (now - bday).ToString(); 
                 Console.WriteLine("Your Age is " + (age.Substring(0, age.LastIndexOf('.'))));
                 Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
    
          
    
    
            
            }
