            for (int i = 0; i < 10; i++)
            {
                string test = chartLeaderBoard.Series["Active Tasks Count"].Points[i].XValue.ToString();
                if (test == selectedUser)
                {
                    chartLeaderBoard.Series["Active Tasks Count"].Points[i].Color = Color.Red;
                }
                else
                {
                    chartLeaderBoard.Series["Active Tasks Count"].Points[i].Color = Color.Blue;
                }            
            }
