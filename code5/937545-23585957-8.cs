    private void Remove()
    {
        if (SelectedItem == null)
        {
            return;
        }
        collection.Remove(SelectedItem);
    }
