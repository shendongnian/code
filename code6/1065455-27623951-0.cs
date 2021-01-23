     private void MyPivot_SelectionChanged(object sender,    SelectionChangedEventArgs e)
            {
                foreach (PivotItem pivotItem in MyPivot.Items)
                {
                    if (pivotItem == MyPivot.Items[MyPivot.SelectedIndex])
                    {
                        //selected
                       ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255,31, 93, 184));
                    }
                    else
                    {
                         // not selected
                        ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255,109, 162, 240 ));
                     }
                 }
             }
