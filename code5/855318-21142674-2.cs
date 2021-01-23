    protected void OnDeleteButtonClick(object sender, EventArgs e)
    {
        var button = sender as LinkButton;
        int rowIndex = int.Parse(button.CommandArgument);
        // Delete the row with index rowIndex.
    }
