        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshButton();
        }
        private void dataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            refreshButton();
        }
        private void refreshButton()
        {
            if (dataGrid.SelectedItem != null)
            {
                Int32 val;
                // This is the first bit that I don't like.  I pulled this code from
                // another website that showed how to get the selected row as a FrameworkElement
                // There is perhaps a more intuitive way to do this
                FrameworkElement element = dataGrid.Columns.Last().GetCellContent(dataGrid.SelectedItem);
                Point selectedRow = element.TransformToAncestor(this).Transform(new Point(0, 0));
                Point grd = dataGrid.TransformToAncestor(this).Transform(new Point(0, 0));
                val = Int32.Parse(Math.Round(selectedRow.Y - grd.Y).ToString());
                // This is the other bit I don't like.  Magic numbers to make sure the delete
                // box doesn't hang out above or below on a scroll.  
                // I think I can get around this by getting the bounds of the elements and
                // doing the math off of that.  I'll probably swing back to it later.
                if (val > 110 || val < 10)
                    DelButton.Visibility = System.Windows.Visibility.Hidden;
                else
                    DelButton.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetTop(DelButton, val);
            }
            else
                DelButton.Visibility = System.Windows.Visibility.Hidden;
        }
