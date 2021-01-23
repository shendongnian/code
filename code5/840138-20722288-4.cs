            int iOneWordTitle = 0;
            string sSearch;
            //Add heading to console
            Console.WriteLine("List of one word film titles");
            Console.WriteLine();
            //ask user what they want to search for
            Console.WriteLine("What film would you like to search for?");
            sSearch = Console.ReadLine();
            //Read all titles from the text file
            string[] titles = File.ReadAllLines("filmnames.txt");
            //Search the array
            bool found = false;
            foreach (string title in titles)
            {
                if (title.Equals(sSearch))
                {
                    Console.WriteLine(sSearch + " was found");
                    found = true;
                }
            }
            //If the title wasn't found, print not found message
            if (!found)
                Console.WriteLine("The film was not found");
