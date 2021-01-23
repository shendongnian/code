    private void lvw_bokade_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
                ListView selectedData = (ListView)sender;
    
                Passlista myPasslista = (Passlista)selectedData.SelectedItem;
    
                System.Windows.Point pt = e.GetPosition(this);
    
                if (myPasslista != null && !(System.Windows.Media.VisualTreeHelper.HitTest(this, pt).VisualHit is ScrollViewer))
                {
                    ContextMenu myContextMenu = new ContextMenu(); ;
    
                    if (MouseButtonState.Released == e.RightButton && myPasslista.Instruktor != "")
                    {
                        MenuItem menuItem3 = new MenuItem();
                        menuItem3.Header = "Add quantity";
                        myContextMenu.Items.Add(menuItem3);
    
                        MenuItem menuItem2 = new MenuItem();
                        menuItem2.Header = "Delete";
                        myContextMenu.Items.Add(menuItem2);
                    }
    
                    myContextMenu.IsOpen = true;
                }
    }
