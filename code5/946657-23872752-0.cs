                Border rect = new Border();
                rect.Width = g.Width;
                rect.Height = g.Height;
                rect.BorderThickness = new Thickness(2);
                rect.BorderBrush = new SolidColorBrush(Colors.Black);        
    
                Grid childGrid = new Grid();
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
                childGrid.ColumnDefinitions.Add(colDef1);
                childGrid.ColumnDefinitions.Add(colDef2);
                childGrid.ColumnDefinitions.Add(colDef3);
                TextBlock txtblk3 = new TextBlock();
                var border = new Border()
                {
                    Background = new SolidColorBrush(Colors.LightGray)
                };
                border.Height = 14;
    
                var border1 = new Border()
                {
                    Background = new SolidColorBrush(Colors.White)
                };
                border1.Height = 14;
    
                Grid.SetColumnSpan(border, 3);
                Grid.SetRow(childGrid, LoopCount);
                childGrid.Children.Add(border);
       
                txtblk3.FontSize = 14;
                txtblk3.FontWeight = FontWeights.Bold;
    
                txtblk3.Text = param.Separator[SeparatorPosition];
                Grid.SetColumn(border1, 1);
                Grid.SetRow(border1,LoopCount);
                border1.Child = txtblk3;    
            
                childGrid.Children.Add(border1);
                g.Children.Add(childGrid);
                return (g);
        
