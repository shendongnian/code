        if (GridView1.Rows.Count > 0)
        {
            int TtlRows = GridView1.Rows.Count;
            int TtlCol = GridView1.Rows[0].Cells.Count;
            int FxdCol = 1;
            int ComputedCol = TtlCol - FxdCol;
            for (int i = FxdCol; i < TtlCol; i++)
            {
                double sum = 0.000;
                for (int j = 0; j < TtlRows; j++)
                {
                    sum += GridView1.Rows[j].Cells[i].Text != "&nbsp;" ? double.Parse(GridView1.Rows[j].Cells[i].Text) : 0.000;
                }
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[i].Text = sum.ToString("#0.000");
                }
            }  
        }
