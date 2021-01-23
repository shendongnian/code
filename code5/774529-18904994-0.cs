    foreach (var tr in tblSchedule.Controls.OfType<TableRow>())
    {
        foreach (var td in tr.Controls.OfType<TableCell>())
        {
            foreach (var rdb in td.Controls.OfType<RadioButton>())
            {
                rdb.Checked = false;
            }
        }
    }
