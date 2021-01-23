    (DataGridViewRow  dgRow in dgvMarksEntryForClass.Rows)
    {
        Decimal cellValue;
        if (Decimal.TryParse(dgRow.Cells["dgcolMarksObtain"].Value, out cellValue)
        {
             //some action
        }
        else
        {
            //some action
        }
    }
