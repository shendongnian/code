            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totSubTot += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SubTotal"));
                TotalAmount =Convert.ToDouble(totSubTot);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                totSubTot += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SubTotal"));
                TotalAmount =Convert.ToDouble(totSubTot);
                e.Row.Cells[2].Text = "Grand Total";
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[3].Text = totSubTot.ToString();
                e.Row.Cells[3].Font.Bold = true;
            }
