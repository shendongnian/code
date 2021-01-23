    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    
    namespace lec022_If_statement_int
    {
    class Program
    {
        //Set to public so it is visible
        //void because it returns nothing
        //Play is a method within the class Program I've added
        public void Play()
        {
            DisplayStr("Lecture 2c | If Statements with ints");
            DisplayReturns();
    
            DisplayStr("Welcome to Dunut King");
            DisplayReturns();
    
            //Collect User Name
            //GetString converts to lower, trims
            int numDonuts = GetInt("How many donuts would you like?: ");
            DisplayReturns();
    
            //Display welcome
            Console.WriteLine("You asked for " + numDonuts + " donuts.");
            DisplayReturns();
    
            DisplayReturns();
            DisplayStr("Have a great Day!");
        }
    
    
    
        //MaxBox 2.0
        public void DisplayStr(String StrTxt)
        { Console.Write(StrTxt); }
    
        public void DisplayReturns()
        { Console.Write("\n\n"); }
    
        public string GetString(String StrVar)//note - using strings here
        {
            Console.Write(StrVar);
            return Console.ReadLine().ToLower().Trim();
        }
    
        public int GetInt(string intVar)//note - using ints here
        {
            Console.Write(intVar);
            return int.Parse(Console.ReadLine());
        }
    
        //Initiate Program
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Play();
    
            Console.Read();
        }
    }
    }
