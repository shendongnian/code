    static void Main(string[] args)
        {
            Console.WriteLine("Give the hight of the pyramid");
            string _spatie = " ";
            string _ster = "*";
            int _aantal = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= _aantal; i++) // loop for height
            {
                for (int d = i; d < _aantal; d++) // loop for spaces
                {
                    Console.Write(_spatie);
                }
    
                for (int e = 1; e <= i; e++) // loop for stars
                {
                    Console.Write(_ster);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
