        protected void Grid_ItemDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;
            
            //cell of all the link button edit/update etc.
            TableCell cell = e.Item.Cells[//index of the column];
            
            foreach(Control c in cell.Controls)
            {
                c.Visible = false;
            }  
        }
