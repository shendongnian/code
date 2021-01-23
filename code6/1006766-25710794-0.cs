        static void Main(string[] args)
        {
            int arraySize = 10;
            string[] Ar = new string[arraySize];
            
            Ar[0] = "A";
            Ar[1] = "B";
            Ar[2] = "C";
            Ar[3] = "D";
            for (int i = 0; i < arraySize; i++)
            {
                if (Ar[i]==null)
                {
                    Ar[i] = "NULL";
                }
            }
            for (int i = 0; i < Ar.Length; i++)
            {
                Console.Write(Ar[i]+" ");
            }
        }
    }
