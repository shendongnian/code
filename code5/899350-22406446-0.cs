    var entries = new SortedList<string, int>
    {
        { txbGroupSeparator.Text, 0 },
        { txbDecimalSeparator.Text, 1 },
        { txbCellDelimiter.Text, 2 }
    };
    okButton.Enabled = txbGroupSeparator.Text == txbDecimalSeparator.Text &&
        txbDecimalSeparator.Text == txbCellDelimiter.Text &&
        !txbCellDelimiter.Text.IsNullOrEmpty();
