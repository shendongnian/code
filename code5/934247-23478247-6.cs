    void TabSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (Mytabcontrol.SelectedItem != null)
        {
            TabItem ti= Mytabcontrol.SelectedItem as TabItem; // Selected Tab
            if (tabitem.Content != null)
            {
                RichTextBox txt = ti.Content as RichTextBox; // your textbox
            }
        }
    }
    
