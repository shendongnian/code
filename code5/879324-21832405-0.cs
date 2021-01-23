    internal void dgv_MouseDown(object sender, MouseEventArgs e)
    {
         DataGridView dgv = (DataGridView)sender;
         List<DataGridViewRow> result = new List<DataGridViewRow>();
         foreach(DataGridViewRow row in dgv.SelectedRows)
         {
             result.Add(row);
         }
         dgv.DoDragDrop(result, DragDropEffects.Copy | DragDropEffects.Move);
    }
    private void dgv_DragEnter(object sender, DragEventArgs e)
    {
         e.Effect = DragDropEffects.Copy;
    }
    private void dgv_DragDrop(object sender, DragEventArgs e)
    {
         try
         {
              DataGridView dataGridView1 = (DataGridView)sender;
              List<DataGridViewRow> rows = new List<DataGridViewRow>();
              rows = (List<DataGridViewRow>)e.Data.GetData(rows.GetType());
              
              //some stuff
         }
     }
 
