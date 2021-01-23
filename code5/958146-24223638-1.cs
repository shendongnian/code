       private void Neighbours_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Include this, check to see if the row is dirty
            if (Neighbours.Rows[e.RowIndex] != null && !Neighbours.Rows[e.RowIndex].IsNewRow && Neighbours.IsCurrentRowDirty)
            {
            DataGridViewRow r = ((DataGridView)sender).Rows[e.RowIndex];
            int dist = 0;
            if (r.Cells["NeighboursStop1"].Value == null || r.Cells["NeighboursStop1"].Value.ToString() == "" || r.Cells["NeighboursStop2"].Value == null || r.Cells["NeighboursStop2"].Value.ToString() == "")
            {
                e.Cancel = true;
                r.ErrorText = "error";
            }
            else if (r.Cells["NeighboursStop1"].Value.ToString() == r.Cells["NeighboursStop2"].Value.ToString())
            {
                e.Cancel = true;
                r.ErrorText = "error";
            }
            else if(!int.TryParse(r.Cells["NeighboursDistance"].Value.ToString(), out dist))
            {
                e.Cancel = true;
                r.ErrorText = "error";
            }
            else if (dist <= 0)
            {
                e.Cancel = true;
                r.ErrorText = "error";
            }
            else
            {
                r.ErrorText = "";
            }
        }
     }
    
