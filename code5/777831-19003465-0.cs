    private void OnSaveClick(object sender, RoutedEventArgs e)
            {
                StackPanel stp = new StackPanel();
                stp.Orientation = Orientation.Horizontal;
                stp.Children.Add(new TextBlock()
                {
                     Text =  string.Format("Item {0}",  lstitems.Items.Count), 
                      HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
                });
    
               Button btn = new Button();
               btn.Content = string.Format("Delete Item {0}",  lstitems.Items.Count);
               btn.Height = 25;
               btn.Width = 100;
               btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
               btn.Click += btnDeleteClick;
    
    
               stp.Children.Add(btn);
    
               lstitems.Items.Add(stp);
            }
