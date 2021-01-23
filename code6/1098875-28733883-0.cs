     Random rnd = new Random();
            int deNumero = rnd.Next(1, 100001);
            while (true)
            {
                Console.WriteLine("DeNomero:{0}", deNumero);
                Console.WriteLine("Pick a number 1 - 100000");
                string input = Console.ReadLine();
                int numero = Int32.Parse(input);
                if (numero < deNumero)
                {
                    Console.WriteLine("Lower");
                }
                else if (numero > deNumero)
                {
                    Console.WriteLine("Higher");
                }
                else if (numero == deNumero)
                {
                    Console.WriteLine("Well done!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("What?");
                }
            }
