    foreach (var data in source)
    {
        Rectangle r = new Rectangle ();
        r.MouseEnter += Rectangle_MouseEnter;
        r.MouseLeave += Rectangle_MouseLeave;
        ...
    }
    ...
    private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
    {
        ((Rectangle)sender).Fill = Brushes.Blue; 
    }
    private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
    {
        ((Rectangle)sender).Fill = Brushes.Yellow;
    }
