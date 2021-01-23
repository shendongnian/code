            int arrayRows = 2;
            int arrayCols = 2;
            char[,] arrayTimes;
            arrayTimes = new char[arrayRows, arrayCols];
            //String star = "*";
            for (int i = 0; i < arrayRows; i++)
            {
                for (int j = 0; j < arrayCols; j++)
                {
                    arrayTimes[i, j] = '*';
                    Console.Write("{0}",arrayTimes[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.ReadKey();
