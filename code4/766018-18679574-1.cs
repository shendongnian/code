    string name;
    bool nameIsCorrect = false;
    do
    {
         Console.WriteLine("Enter Name");
         name = Console.ReadLine();
         nameIsAshley = string.Equals(name, "ashley", StringComparison.CurrentCultureIgnoreCase);
 
         if (nameIsAshley)
         {
            Console.WriteLine("Stop entering 'ashley'");
         }
    }
    while (!nameIsAshley);
