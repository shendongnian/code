        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
                return;
            
            DataRowView row = e.Row.DataItem as DataRowView;
            if(row["Space"] != "")
            {
                string s = row["Space"].ToString();
                //do stuff
            }
        }
