     <ListBox Name="listbox" SelectionChanged="changed" SelectionMode="Multiple">
            <ListBox.Items>
                <ListBoxItem>one</ListBoxItem>
                <ListBoxItem>two</ListBoxItem>
            </ListBox.Items>
        </ListBox>   
     private void changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            for (int index = 0; index < listbox.SelectedItems.Count; index++)
                listbox.Items.Remove(listbox.SelectedItems[index]);
        }
