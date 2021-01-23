        static Element[] WczytajDaneZKonsoli()
        {
            List<Element> elements = new List<Element>();
            Console.WriteLine("Keep on entering numbers, enter X once you're done");
            Console.WriteLine("Podawaj liczby. Wpisz X aby zakończyć i przejść do sortowania.");
            while (true)
            {                
                string str = Console.ReadLine();
                if (str == "X")
                {
                    break;
                }
                int element;
                try
                {
                    element = int.Parse(str);
                    elements.Add(new Element(element));
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wprowadzono liczbę w złym formacie");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wartość jest za duża albo za mała, pamiętaj że możesz podać liczby z zakresu 1 do 4294967295");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Napotkano koniec strumienia");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("Spróbuj jeszcze raz");
            }
            return elements.ToArray();
        }
