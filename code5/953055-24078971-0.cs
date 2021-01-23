            int index = 5; //say you want to display upto 5th element
            ListBox lines = new ListBox();
            lines.Width = 100;
            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            for (int i = 0; i < 5; i++)
            {
    
                lines.Items.Add(new ListBoxItem
                            {
                               Content = i.ToString()
                            });
            }
            foreach (ListBoxItem lv in lines.Items)
            {
                lv.Height = 10;
    
            }
            scrollViewer.Height = index * 10;
            scrollViewer.Content = lines;
            Grid.SetColumn(scrollViewer, 1);
            childGrid.Children.Add(scrollViewer);
