    Grid test = new Grid();
    for (int j = 0; j <= rows1; j++)
    { 
        RowDefinition row = new RowDefinition();
        row.Height = new GridLength(50);
        test.RowDefinitions.Add(row);
        for (int i = 0; i <= cols1; i++)
        {
            if (array[i, j] != null)
            {
                if(j == 0)
                { 
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = new GridLength(50);
                    test.ColumnDefinitions.Add(col);
                }
                Image img = new Image();
                img.source = new BitmapImage(new Uri("testimg.jpg", urikind.Relative));
                Grid.SetRow(img, j);
                Grid.SetColumn(img, i);
                test.Children.Add(img);
            }
            else
            {
                i--;
            }
        }
    }
