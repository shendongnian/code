    Listbox.SelectedIndex = 0;
    
    private void Listbox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key== Key.Enter)
        {
             if(Listbox.Items.Count-1>Listbox.SelectedIndex)
                 Listbox.SelectedIndex++;
             else 
                 Listbox.SelectedIndex=0;
        }
    }
