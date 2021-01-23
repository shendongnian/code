        try
        {
        int _SeletedIndex = listBox.SelectedIndex();
        listBox.Items.Remove(listBox.SelectedItems[0]);
        people.RemoveAt(_SeletedIndex);
        }
        catch { }
 
