    namespace Test2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] Namen = new string[5];
                int[] Lefftijd = new int[5];
                int index=0;
                for(int i = 0; i<Namen.Length;i++)
                {
                    Console.Write("Geef de naam : ");
                    Namen[index++] = Console.ReadLine();
                }
    
                index = 0;
                for(int j = 0 ; j < Lefftijd.Length; j++)
                {
                    Console.Write("Geef de leeftijd : ");
                    Lefftijd[index++] = Convert.ToInt32(Console.ReadLine());
    
                }
                Console.WriteLine("De namen zijn  " + Namen.Length + " en aantal leftijden zijn : " + Lefftijd.Length);
                Console.WriteLine();
                Console.WriteLine("De naam is : " + Namen[index] + " De leftijd is : " + Lefftijd[index]);
                Console.ReadLine();
            }
        }
    }
