    class CompareLists
    {        
        static void Main()
        {
            // Create the IEnumerable data sources. 
            string[] names1 = System.IO.File.ReadAllLines(@"../../../names1.txt");
            string[] names2 = System.IO.File.ReadAllLines(@"../../../names2.txt");
    
            // Create the query. Note that method syntax must be used here.
            IEnumerable<string> differenceQuery =
              names1.Except(names2);
    
            // Execute the query.
            Console.WriteLine("The following lines are in names1.txt but not names2.txt");
            foreach (string s in differenceQuery)
                Console.WriteLine(s);
    
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output:
         The following lines are in names1.txt but not names2.txt
        Potra, Cristina
        Noriega, Fabricio
        Aw, Kam Foo
        Toyoshima, Tim
        Guy, Wey Yuan
        Garcia, Debra
         */
