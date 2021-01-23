        for (int c = 0; c < 4; c++)
        {
            TableRow tr1 = new TableRow();
            for (int cc = 0; cc < 4; cc++)
            {
                TableCell tc1 = new TableCell();
                tc1.Text = "|empty Cell|";
                tr1.Cells.Add(tc1);
            }
            tbleEquipment.Rows.Add(tr1);
        }
