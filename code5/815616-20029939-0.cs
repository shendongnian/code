      public static void Sort(string[,] original)
        {
            var data=new List<List<string>>();
            for (int i = 0; i < original.GetLength(0); i++)
            {
                var m=new List<string>();
                for (int j = 0; j < original.GetLength(1); j++)
                {
                   m.Add(original[i,j]) ; 
                }
                data.Add(m);
            }
            var l = data.OrderBy(x => int.Parse(x[2])).ToList();
            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    original[i, j] = l[i][j];
                }
            }
        }
