     void ti_PreviewMouseDown(object sender, MouseButtonEventArgs e)
     {
          TabItem clickedTabItem = sender as TabItem;
          if (clickedTabItem != null)
          {               
               if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
               {
                    // Do whatever you want to do with clickedTabItem here, I'm removing it from the TabControl
                    MyTabControl.Items.Remove(clickedTabItem);
               }
          }
     }
