            double[,] numbers = new double[,]{ { 1, 3, 2 }, { 4, 6, 5 }, { 7, 9, 8 } };
            // helper class
            double temp = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (numbers[k,i] < numbers[k,j])
                        {
                            temp = numbers[k,i];
                            numbers[k,i] = numbers[k,j];
                            numbers[k,j] =temp;
                        }
                    }
                }
            }
