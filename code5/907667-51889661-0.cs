                Button[,] Buttons = new Button[8, endTimePlus1 - startTime];
            var buttons = controlGrid.Children.Cast<Button>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < endTimePlus1 - startTime; j++)
                {
                    Buttons[i,j] =  buttons.Where(x => Grid.GetRow(x) == j && Grid.GetColumn(x) == i).FirstOrDefault();
                }
            }
