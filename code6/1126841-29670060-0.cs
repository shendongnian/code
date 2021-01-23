    You can use The Visual Tree to achieve this.
    
     public List<Control> ChildrensList(DependencyObject parent)
            {
                List<Control> list = new List<Control>();
    
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent,i);
    
                    if (child is Control)
                        list.Add(child as Control);
    
                    list.AddRange(ChildrensList(child));
                }
    
                return list;
            }
