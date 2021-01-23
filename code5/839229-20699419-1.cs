    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string initialText = SearchTextBox.Text;
        SearchTextBox.TextChanged -= SearchTextBox_TextChanged;
        do
        {
            ListBox.Items.Clear();
            foreach (Item a in arr)
            {
                 if(a.Title.Contains(initialText))
                 {
                    ListBox.Items.Add(a);
                 }
            }
        } while (SearchTextBox.Text != initialText)
        SearchTextBox.TextChanged += SearchTextBox_TextChanged;
    }
