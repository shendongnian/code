                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(MainPivotControl); i++)
                {
                    var child = VisualTreeHelper.GetChild(MainPivotControl, i);
                    if (child is Button)
                    {
                        var button = child as Button;
                        if (button.Name == "HomeButton")
                        {
                            //Here do whatever you want to do with HomeButton
                            break;
                        }
                        
    
                        
                    }
                }  
