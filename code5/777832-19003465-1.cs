      void btnDeleteClick(object sender, RoutedEventArgs e)
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                   var st = FindParent<StackPanel> (btn); //stackpanel as we have added item as stackpanel.
                   if (st != null)
                       lstitems.Items.Remove(st);
                }
            }
