    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName != "Participants")
        { e.Column.IsReadOnly = true; }
    }
