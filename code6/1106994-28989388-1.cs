    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        ToolTip tt = btn.ToolTip as ToolTip;
    
        if (tt.PlacementTarget == null)
        {
            tt.PlacementTarget = btn;
        }
    
        tt.IsOpen = true;
    }
