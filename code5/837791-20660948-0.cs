    void myMethod(object sender, System.Windows.Controls.DataGridRowEventArgs e)
    {
            RowClass item = (RowClass)e.Row.Item;
            if (item.IsHighlighted)
            {
                e.Row.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                e.Row.Background = new SolidColorBrush(Colors.White);
            }
    }
