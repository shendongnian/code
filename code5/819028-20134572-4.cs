    void Move()
    {
        var ads = new Rectangle[] { Ad1, Ad2, Ad3, Ad4, Ad5, Ad6, Ad7 };
        foreach (var item in ads)
        {
            var row = (int)item.GetValue(Grid.RowProperty);
            var col = (int)item.GetValue(Grid.ColumnProperty);
            var x = item.ActualWidth;
            var y = item.ActualHeight;
            // bottom
            if (row == 3)
            {
                // left-last
                if (col == 0)
                {
                    row = 0;
                    col = 3;
                    x = -x;
                    y = 0;
                }
                // others
                else
                {
                    col--;
                    x = -x;
                    y = 0;
                }
            }
           // right
           else
            {
               // bottom-last
               if (row == 2)
                {
                    row = 3;
                    col = 2;
                    x = -x;
                }
                else
                {
                    row++;
                    x = 0;
                }
            }
            var dr = new Duration(TimeSpan.FromSeconds(.5));
            var tx = item.RenderTransform = new TranslateTransform();
            var ax = new DoubleAnimation { To = x, Duration = dr };
            Storyboard.SetTarget(ax, tx);
            Storyboard.SetTargetProperty(ax, "X");
            var ay = new DoubleAnimation { To = y, Duration = dr };
            Storyboard.SetTarget(ay, tx);
            Storyboard.SetTargetProperty(ay, "Y");
            var st = new Storyboard { FillBehavior = FillBehavior.HoldEnd };
            st.Children.Add(ax);
            st.Children.Add(ay);
            st.Completed += (s, e) =>
            {
                item.SetValue(Grid.RowProperty, row);
                item.SetValue(Grid.ColumnProperty, col);
                st.Stop();
            };
            st.Begin();
        }
    }
