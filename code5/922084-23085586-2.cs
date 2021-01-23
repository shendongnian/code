    private void HandleEsc(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape) Close();
        if (e.Key == Key.Enter ||
            e.Key == Key.Tab) SearchAndDisplay(e.OriginalSource)
    }   
    private void SearchAndDisplay(object sender)
    {
        if(sender is Control)
        {
            MessageBox.Show(((Control)sender).Name);
        }
    } 
