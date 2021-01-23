                ListBox lines = new ListBox(); 
                ScrollViewer scrollViewer = new ScrollViewer();            
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                foreach (var item in param.Component.Attributes.Items)
                {
                    lines.Items.Add(item);    
                    scrollViewer.Content = lines;                            
                }                
            Grid.SetColumn(scrollViewer, 1);
            Grid.SetRow(scrollViewer, LoopCount);
            childGrid.Children.Add(scrollViewer);
