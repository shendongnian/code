    var LotteryArray = Matrix(Rows, Columns);
    foreach (int i in Winner) 
        {
            for (int j = 0; j<LotteryArray; j++)
            {
                if (Winner[i] == j)
                {
                    Prediction++;
                    if (j % 6 == 0) { RowNum++; }
                }
                Console.WriteLine("you got {0} correct prediction in row number {1}",Prediction,RowNum);
                RowNum = 1;
            }
        }
