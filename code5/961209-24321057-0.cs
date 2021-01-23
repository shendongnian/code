    private void btn_addnew_Click(object sender, RoutedEventArgs e)
            {
                
                var myControl = sender as Button;
                int rowindex = (int)myControl.GetValue(Grid.RowProperty);
    
                foreach (UIElement control in grid_typeFixture.Children)
                {
                    var usercontrol = control as UserControlTypeofFixture;
                    if (usercontrol != null)
                    {
                        int childrowindex = (int)usercontrol.GetValue(Grid.RowProperty);
                        if (childrowindex == rowindex)
                        {
                            grid_typeFixture.Children.Remove(control);
                            grid_typeFixture.RowDefinitions.RemoveAt(childrowindex);
                            break;
                        }
                    }
                    
                }
               
            }
