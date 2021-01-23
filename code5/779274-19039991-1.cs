    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    
    class Program
    {
        public static List<User> Users;
    
        static void Main(string[] args)
        {
                Users = new List<User>
                {
                    new User
                        {
                            FirstName = "Brett",
                            LastName = "M"
                        },
                    new User
                        {
                            FirstName = "John",
                            LastName = "Doe"
                        },
                new User
                    {
                        FirstName = "Sam",
                        LastName = "Dilat"
                    }
                };
    
            Console.WriteLine("Should work as long as object is defined and instantiated");
            Console.WriteLine(Users.ElementAt(1).FirstName);
                
    
            Console.WriteLine("\nIterate Through List with Linq\n I use a string you can add to another list or whatever\n\n");
    
            string s = "";
    
            Users.ForEach(n => s += "Position: " + Users.IndexOf(n) + " " + n.LastName + Environment.NewLine);
            Console.WriteLine(s);
    
            Console.ReadLine();
        }
    
    }
