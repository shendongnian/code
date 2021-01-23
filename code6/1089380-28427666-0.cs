     int counter=0;
            for (int row = 0; row < 8; row++)
            { 
                if (matrix[row, column] == 1)
                {
                    if (counter==3)
                      {
                        Console.WriteLine(column);
                        break;
                       
                      }
                    else
                      {
                       counter++;
                      }
                }
               
            }
