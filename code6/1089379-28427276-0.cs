            var counter=0;
            for (var column = 0; column < 8; column++)
            {
                for (var row = 0; row < 8; row++)
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
