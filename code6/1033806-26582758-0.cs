    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Activators
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("enter New Log in name");
                string CashierLOgInNName = Console.ReadLine();
    
                Console.WriteLine("enter First Name");
                string CashierFirstName = Console.ReadLine();
                Console.WriteLine("enter Last name");
                string CashierLastName = Console.ReadLine();
                Console.WriteLine("enter Cashier ID");
                string f = Console.ReadLine();
                int NewCashierID = Int32.Parse(f);
                Console.WriteLine("enter Cashier Password");
                string g = Console.ReadLine();
                Cashiers cashierObj = (Cashiers)Activator.CreateInstance(typeof(Cashiers), f, g, CashierFirstName, CashierLastName);
            }
        }
        public class Cashiers
        {
            public string CashierID;
            public string Password;
            public string FirstName;
            public string LastName;
            public Cashiers(string CashierID, string Password, string FirstName, string LastName)
            {
                this.CashierID = CashierID;
                this.Password = Password;
                this.FirstName = FirstName;
                this.LastName = LastName;
            }
        }
    }
