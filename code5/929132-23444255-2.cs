    private void NewRow(object obj)
    {
        if (SelectedRow == People.Last())
        {
            if (SelectedConfirmation == "Add New")
            {
                if (SelectedCell.Column.Header.ToString() == "Confirmation")
                {
                    People.Add(new Person());
                }
            }
        }
    }
