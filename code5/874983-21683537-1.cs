    if (YearNumb<1900 || YearNumb>3000)
            {
                Console.WriteLine("Du angav inte ett år mellan 1900 och 3000.");
                Console.ReadLine();
                return;
            }
    else if (YearNumb.ToString().Length != 4)
               {
                Console.WriteLine("text");
                Console.ReadLine();
                return;
            } 
