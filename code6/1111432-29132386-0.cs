        public void OnRowDataBound(Object sender, GridViewRowEventArgs e)
        {
            // convert time display to another format
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
            {
                e.Row.Cells[4].Text = process(e.Row.Cells[4].Text);
            }
        }
