        private void ShowHideDetailsClick(object sender, RoutedEventArgs e)
        {
  
          System.Windows.Controls.Button expandCollapseButton =  (System.Windows.Controls.Button)sender;
          DependencyObject obj = (DependencyObject)e.OriginalSource;
         while (!(obj is ExtendedGrid.Microsoft.Windows.Controls.DataGridRow) && obj != null) obj = VisualTreeHelper.GetParent(obj);
         //Get your entire row view here
           if(obj != null && obj is ExtendedGrid.Microsoft.Windows.Controls.DataGridRow)
           {
              DataGridRow d = obj as DataGridRow; //Convert into DataGridRow
              PopulateData st = d.Item as PopulateData; //Get the PopulateData
 
              if (st.TraderID == "what you wants") //Or something else in the Class
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
