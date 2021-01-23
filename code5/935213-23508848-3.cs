    private void Notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (Note note in e.AddedItems)
        {
            MessageBox.Show(note.Body);
        }
    }
