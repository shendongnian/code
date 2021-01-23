      TableCell quanti = new TableCell();
        TextBox tb = new TextBox();
         quanti.Attributes.Add("data_qty","100");
        tb.ID = reader["Book_ID"].ToString();
        tb.Text = "100";
        tb.Width = 66;
        quanti.Controls.Add(tb);
        detailsRow.Cells.Add(quanti);
