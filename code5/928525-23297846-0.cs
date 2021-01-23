    static Element[] WczytajDaneZKonsoli()
        {
            Element[] elements=new Element[500];
            while (true)
            {
                string str = Console.ReadLine();
                int element;
    
                try
                {
                    element = int.Parse(str);
                    elements.Add(element);
                    break;
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
            return elements;
        }
