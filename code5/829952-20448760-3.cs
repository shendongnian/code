    private void ListBoxItem_MouseEnter(object s, MouseEventArgs e)
    {
        var item = e.OriginalSource as ListBoxItem;
        // depends on what we have put in the content. e.g. string.
        var content = item.Content as string; 
    }
