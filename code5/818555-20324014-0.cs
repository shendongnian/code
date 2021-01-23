    private void CreateGraphicalDisplay(int rows,int columns,int row,int column)
        {
            
            for (int i = 1; i <= rows; i++)
            {
            StackPanel childstack = new StackPanel();
           
            for (int j = 1; j <= columns; j++)
            {
                Image gage = new Image();
                gage.Stretch = Stretch.Fill;
                if (i == row && j == column)
                {
                    gage.Source = new BitmapImage(new Uri(@Highlightedimage));
                }
                else
                {
                    gage.Source = new BitmapImage(new Uri(@normalimage));
                }
                gage.Width = 12;
                gage.Height =12;
                gage.HorizontalAlignment = HorizontalAlignment.Left;
                gage.Margin = new Thickness(10, 1, 1, 1);
           
                childstack.Children.Add(gage);
            }
            
                containerstack.Children.Add(childstack);
            }
        }
