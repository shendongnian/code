    private void Grid_View_Btn_1_Click(object sender, System.Windows.RoutedEventArgs e)
        {   Dispatcher.BeginInvoke(() => {         
             StackPanel panel = new StackPanel();
             panel.Orientation = System.Windows.Controls.Orientation.Vertical;
                   int i;
                   for (i=0;i<5;i++)
                     {
                        Button btn = new Button() { Content = "Button" };
                        btn.Width=130;
                        btn.Height = 66;
                       // btn.Margin = new Thickness(0,0,0,0)//try this if you use grid
                        //grid.Children.Add(btn);
                     panel.Children.Add(btn);
                     grid.Children.Add(panel);
                     }
        
            //       Grid.SetRow(control, i);
            //    Grid.SetColumn(control, j);
            // TODO: Add event handler implementation here.
             });
        }
