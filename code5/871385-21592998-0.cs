    using System.Diagnostics;
    using System.IO;
    
    ...
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string filename = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            if(e.ColumnIndex == 3 && File.Exists(filename))
            {
                Process.Start(filename);
            }
            
        }
