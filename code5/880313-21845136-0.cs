    foreach (System.Windows.Forms.DataGridViewRow r in MyGridView.Rows)
    {
          if ((r.Cells[5].Value).ToString().ToUpper().Contains(searchText.ToUpper()))
          {
                MyGridView.Rows[r.Index].Visible = true;
                MyGridView.Rows[r.Index].Selected = true;
          }
          else
          {
                MyGridView.CurrentCell = null;
                MyGridView.Rows[r.Index].Visible = false;
          }
     }
