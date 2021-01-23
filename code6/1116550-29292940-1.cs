            for (int i = 0; i < a.Length; i++)
            {
                var innerArray = a[i];
                for (int f = 0; f < innerArray.Length; f++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (b[j] == innerArray[f])
                        {
                            Count++;
                        }
                    }
                } 
            } 
