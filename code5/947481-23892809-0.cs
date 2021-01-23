    this.lines.SelectionChanged+=new System.EventHandler(this.UpdateTextBlock);
    
    private void UpdateTextBlock(object sender, SelectionChangedEventArgs e)
    {
        this.txtblkShowSelectedValue.Text=this.lines[(sender as Listbox).SelectedIndex].ToString();
    }
