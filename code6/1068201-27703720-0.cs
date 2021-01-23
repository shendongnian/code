    static void Main(string[] args) 
    {
        string username;
        int password, count=0 , num_guest , age;
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Username : ");
            username = Console.ReadLine().ToString();
            Console.Write("Password : ");
             password = Convert.ToInt32(Console.ReadLine());
    
             if (password.Equals(63100))
             {
                 Console.Clear();
                 Console.WriteLine("Welcome " + username);
                 Console.Write("Enter number of guests : ");
                 num_guest = Convert.ToInt32(Console.ReadLine());
    
                 if (num_guest <= 0)
                 {
                     Console.Clear();
                     Console.WriteLine("Thank You");
                     Environment.Exit(0);
                 }
                     else
                 {
                     //make counter here 
                     for (int j = 1; j <num_guest+1; j++)
                     {
                         Console.Write("Enter age of "+j+" guest : ");
                         age = Convert.ToInt32(Console.ReadLine());
    
                             if (age >= 0)
                             {
                                 //reset counter here
                                 if (age == 0 && age == 1)
                                 {
                                     count = count + 0;
                                 }
                                 else if (age >= 2 && age <= 17)
                                 {
                                     count = count + 60;
                                 }
    
                                 else if (age >= 18 && age <= 59)
                                 {
                                     count = count + 35;
                                 }
    
                                 else if (age > 60)
                                 {
                                     count = count + 30;
                                 }
                             }
                             else
                             {
                                // minus 1 of j  increment counter here if counter hits 3 then ouput message then terminate program
                             }
    
                     }
    
                     Console.WriteLine(count);
                     Console.ReadLine();
    
                 }
    
                 break;
             }
             else
             {
                 Console.WriteLine("Incorrect Password!");
             }
        }
    
        Console.Clear();
        Console.WriteLine("Bye..." );
        Environment.Exit(0);
    
    }
