            for (int column = 0; column < 8; column++)
            {
                int counter=0;
                for (int row = 0; row < 8; row++)
                { 
                    if (matrix[row, column] == 1)
                    {
                        counter++;
                    }
                    if (counter==3)
                    {
                        Console.WriteLine(column);
                        break;
                    }
                }                    
            }
