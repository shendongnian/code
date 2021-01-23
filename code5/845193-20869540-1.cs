    public static void display()
        {
            var boardStr = new StringBuilder();
           
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    bool packFound = false;
                    bool enmFound = false;
                    foreach (Packman element in myVers.packmans)
                    {
                        if (element.x == i && element.y == j)
                        {
                            packFound = true;
                            break;
                        }
                    }
                    foreach (Packman element in myVers.enemys)
                    {
                        if (element.x == i && element.y == j)
                        {
                            enmFound = true;
                            break;
                        }
                    }
                    if (packFound == true)
                    {
                       boardStr.Append("0");
                        myVers.board[i, j] = ' ';
                    }
                    else if (enmFound == true)
                    {
                        myVers.board[i, j] = ' ';
                        boardStr.Append("#");
                    }
                    else
                    {
                        boardStr.Append(myVers.board[i, j].ToString());
                    }
                }
                boardStr.Append("\n");
            }
            //Console.Write("\nFood Count " + myVers.foodCount + "\n");
            Console.Clear();
            Console.Write(boardStr.ToString());
        }
