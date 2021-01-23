        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow item = e.Row;
                int myvar;
                Int32.TryParse(item.Cells[0].Text, out myvar);
                if (dictionaryIds.ContainsKey(myvar))
                    item.Cells[3].Text = dictionaryIds[myvar].ToString();
            }
        }
