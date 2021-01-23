        private void table_click(object sender, RoutedEventArgs e)
        {
            //Creation of Grid
            Grid tablegrid = new Grid();
            tablegrid.Height = double.NaN;
            tablegrid.Width = double.NaN;
            tablegrid.Margin = new Thickness(0, 66, 0, 0);
           // tablegrid.ShowGridLines = true;
            tablegrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tablegrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            
            
            //Table Rows and Columns Definition
            string[] tablerow = new string[] { "Submit Report","Arsal","AA","Mansab","a","e"};
            string[] tablecol = new string[] { "Mansab","Ali","Aly","Ayaz" };
            int i, j;
            for (i = 0; i < tablerow.Length; i++)
            {
                RowDefinition gridrows = new RowDefinition();
                gridrows.Height = new GridLength(66);
                tablegrid.RowDefinitions.Insert(i, gridrows);
            }
            for (j = 0; j < tablecol.Length; j++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                tablegrid.ColumnDefinitions.Insert(j, gridCol);
            }
          
         // Setting background Image for all rows and columns Dynamically
   
            int k = 0;
            for (k = 0; k < tablecol.Length; k++)
            {
                Border brd = new Border();
                brd.Height = 66;
                brd.Width = 460;
                brd.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                Grid.SetRow(brd, 0);
                Grid.SetColumnSpan(brd, tablecol.Length);
                tablegrid.Children.Add(brd);
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Resources/Images/top_bar_bg.png", UriKind.Relative));
                brd.Background = brush;
            }
            int l;
            for (l = 0; l < tablecol.Length; l++)
            {
                Border brd = new Border();
                brd.Height = 66;
                brd.Width = 460;
                brd.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                Grid.SetRow(brd, 1);
                Grid.SetColumnSpan(brd, tablecol.Length);
                tablegrid.Children.Add(brd);
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Resources/Images/table_row_blue.png", UriKind.Relative));
                brd.Background = brush;
            }
          ContentPanel.Children.Add(tablegrid);
       }
