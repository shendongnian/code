       private void SearchElement(DependencyObject targeted_control) 
          {           
          var count = VisualTreeHelper.GetChildrenCount(targeted_control);   // targeted_control is the Canvas  
          if (count > 0)
            {
            for (int i = 0; i < count; i++)
              {
              var child = VisualTreeHelper.GetChild(targeted_control, i);
              if (child is Button ) // specific button control 
                {
                 // do your logic
                }
              }
           }
        }
