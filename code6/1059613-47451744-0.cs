    System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];.
    Do the Following changes in your program:
     private void button1_Click (object sender, EventArgs e)      
     {
    
     try
      {
        if (dataGridView1.RowCount != 0)
        {
    
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {                                       
                ((Form1)f).dataGridView1.Rows.Add(row);                    
            }
    
          }
        else
        {
            MessageBox.Show("There is no data to export, please verify..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    catch { }   }
