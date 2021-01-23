     private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            DataGridView.HitTestInfo info = dataGridView1.HitTest(e.X, e.Y);
            if (info.RowIndex >= 0)
            {
                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                {
                    string text = (String)
                           dataGridView1.Rows[info.RowIndex].Cells[info.ColumnIndex].Value;
                    if (text != null){
                         //Need to put braces here  CHANGE
                        dataGridView1.DoDragDrop(text, DragDropEffects.Copy);
                    }
                }
            }
        }
    }
     private void dataGridView2_DragDrop(object sender, DragEventArgs e)
    {
        string cellvalue=e.Data.GetData(typeof(string)) as string;
        Point cursorLocation=this.PointToClient(new Point(e.X,e.Y));
        System.Windows.Forms.DataGridView.HitTestInfo hittest= dataGridView2.HitTest(cursorLocation.X,cursorLocation.Y);
        if (hittest.ColumnIndex != -1
            && hittest.RowIndex != -1){  //CHANGE
            dataGridView2[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;
       }
    }
    private void dataGridView2_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
