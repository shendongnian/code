        private void ShowHideDetailsClick(object sender, RoutedEventArgs e)
        {
  
          System.Windows.Controls.Button expandCollapseButton =  (System.Windows.Controls.Button)sender;
          DependencyObject obj = (DependencyObject)e.OriginalSource;
         while (!(obj is ExtendedGrid.Microsoft.Windows.Controls.DataGridRow) && obj != null) obj = VisualTreeHelper.GetParent(obj);
         //Get your entire row view here
           if(obj != null && obj is ExtendedGrid.Microsoft.Windows.Controls.DataGridRow)
           {
              var row = (DataRowView)obj.Row.Item;
              var content = row.Row[3].ToString(); // make sure the third exists
              if (content.Equals("what you wants"))
              {
                // some stuff here
              } 
           }
           
     
            if (obj is ExtendedGrid.Microsoft.Windows.Controls.DataGridRow)
            {
               if (null != expandCollapseButton && "+" == expandCollapseButton.Content.ToString())
               {
                 (obj as ExtendedGrid.Microsoft.Windows.Controls.DataGridRow).DetailsVisibility = Visibility.Visible;
                 expandCollapseButton.Content = "-";
               }
                else
                {
                  (obj as ExtendedGrid.Microsoft.Windows.Controls.DataGridRow).DetailsVisibility = Visibility.Collapsed;
                expandCollapseButton.Content = "+";
                }
            }
         }
