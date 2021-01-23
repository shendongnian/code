            string Vraag1 = ("Wat is de hoofstad van Oostenrijk?");
            string Solution1 = ("Wenen");
            string Keuze1 = ("a: Wenen b: Rome c: Kiev");
            string Vraag2 = ("Hoe heet de hoogste berg van Afrika?");
            string Solution2 = ("De Kilimanjaro");
            string Keuze2 = ("a: De Mount-everest b: De Kilimanjaro c: De Aconcagua");
            string Vraag3 = ("Wie was de uitvinder van de gloeilamp?");
            string Solution3 = ("Edison");
            string Keuze3 = ("a: Thomas Edison b: Albert Einstein c: Abraham Lincoln");
            //Other variables
            //entered1, 2 and 3 are variables that the user typed in
            //code
            //Question 1
            Console.WriteLine("Vraag 1:");
            Console.WriteLine();
            Console.WriteLine(Vraag1);
            Console.WriteLine();
            Console.WriteLine(Keuze1);
            string entered1 = Console.ReadLine();
            Boolean enteredbool1 = entered1.Equals("a");
            if (enteredbool1)
            {
                Console.ForegroundColor = (ConsoleColor.Green);
                Console.WriteLine("Goedzo, op naar de volgende!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("FOUT!");
                Console.ReadLine();
            }
