    public void editForm(DataGridView dg)
    {
        var textBoxes = 
            Enumerable.Range(0, dg.Columns.Count)
                      .Select(i => new TextBox())
                      .ToArray();
    }
