     public void load()
        {
            for (int i = 0; i <= 4; i++)
            {                
                for (int j = 0; j <= 4; j++)
                {
                    Console.WriteLine("enter value for {0},{1}", i, j);
                    matrix[i,j]= int.Parse(Console.ReadLine());
                }
            }
        }
