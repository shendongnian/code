    foreach(GridViewItem grvItem in UsrGridView.Items)
    {
        StackPanel sp = grvItem.Content as StackPanel;
        if (sp != null)
        {
            foreach(var c in sp.Children)
            {
                TextBlock tb = c as TextBlock;
                if (tb != null)
                {
                    //...
                }
            }
        }   
    }
