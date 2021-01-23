    foreach (UIElement pnl in mainpanel.Children)
    {
        if (pnl is StackPanel)
        {
            foreach (UIElement ctrl in pnl.Children)
            {
                 if (ctrl is TextBox)
                 {
                   // your logic here
                 }
            }
        }
    }
