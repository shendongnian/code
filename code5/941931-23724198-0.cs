    void b1_click(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var b1 = (Button) sender;
            a.Controls.RemoveByKey(b1.Name);
            No1(b1.TopLevelControl, b1.Location.X, b1.Location.Y);
        }                   
    }
