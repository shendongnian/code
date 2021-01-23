         for (int c = 0; c < 4; c++)
         {
            TableRow tr1 = new TableRow();
            for (int cc = 0; cc < 4; cc++)
            {
                TableCell tc1 = new TableCell();
                TextBox tb1 = new TextBox();
                tb1.ID = "txtTextBox" + cc.ToString();
                tc1.Controls.Add(tb1);
                tr1.Cells.Add(tc1);
            }
            tbleEquipment.Rows.Add(tr1);
         }
