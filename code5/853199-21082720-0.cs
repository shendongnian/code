    private List<String[]> _listItems = new List<String[]>();
    private List<Int32> _hiddenIndexes = new List<Int32>();
    private void UpdateCollection()
    {
        listBox.Items.Clear();
        for (Int32 i = 0; i < _listItems.Count; i++)
        {
            if (!_hiddenIndexes.Contains(i))
                listBox.Items.Add(new ListBoxItem(_listItems[i]));
        }
    }
