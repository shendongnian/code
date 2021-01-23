    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            Boolean flag = true;
            //I can only run it after I set it to static
            static SubMenu sm = new SubMenu();
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Console Application v1.0 created by");
                    Console.WriteLine();
                    Console.WriteLine(" ---------------------------------------------------");
                    Console.WriteLine(" -|-------------- MENU ---------------------------|-");
                    Console.WriteLine(" -|-----------------------------------------------|-");
                    Console.WriteLine(" -|- 1 -  Create a Person                        -|-");
                    Console.WriteLine(" -|- 2 -  List all the Persons                   -|-");
                    Console.WriteLine(" -|- 3 -  Search for a Person                    -|-");
                    Console.WriteLine(" -|- 4 -  Display the number of Persons          -|-");
                    Console.WriteLine(" -|- 5 -  Exit                                   -|-");
                    Console.WriteLine(" ---------------------------------------------------");
                    Console.Write(" Enter your choice: ");
                    string UserInput = Console.ReadLine();
                    Console.WriteLine();
    
                    int input;
                    if (int.TryParse(UserInput, out input))
                    {
                        switch (input)
                        {
                            case 1: Console.WriteLine("Case 1");
                                sm.SMenu();
                                break;
                            case 2: Console.WriteLine("Case 2");  //displaying one now if run once
                                int size = sm.MyList.Count;
                                Console.WriteLine("Size :" + size);
    
                                break;
                            case 3: Console.WriteLine("Case 3");
                                break;
                        }
                    }
                }
            }
    
            class SubMenu
            {
                //CreatePersons cp;
                //replace Person with int
                List<int> myList = new List<int>();
                public List<int> MyList
                {
                    get { return myList; }
                }
    
                string UserInput = null;
                public void SMenu()
                {
    
                    Boolean flag = true;
                    //the original while(true) makes me never go out from loop, so I change it.
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine(" -------------------------------------------");
                        Console.WriteLine(" -|---------------------------------------|-");
                        Console.WriteLine(" -|- P. Create a Person                  -|-");
                        Console.WriteLine(" -|- S. Create a Student                 -|-");
                        Console.WriteLine(" -|- T. Create a Teacher                 -|-");
                        Console.WriteLine(" -|- A. Create Administrative Staff      -|-");
                        Console.WriteLine(" -|- R. Return to Main Menu              -|-");
                        Console.WriteLine(" -|---------------------------------------|-");
                        Console.WriteLine(" -------------------------------------------");
                        Console.Write(" Enter your choice: ");
                        UserInput = Console.ReadLine();
    
                        switch (UserInput.ToLower())
                        {
                            //remove the Person part
                            case "p": myList.Add(1);   //For testing
                                Console.WriteLine(myList.Count);    //Count = 1
                                break;
                            case "s": Console.WriteLine("Creates and object of type Student.");
                                break;
                        }
                    } while (false);
                }
            }
        }
    }
