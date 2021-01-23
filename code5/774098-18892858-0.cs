           DataGridViewRowCollection rowCollection = dataGridView1.Rows;
            label1.Text = "";
            foreach (DataGridViewRow item in rowCollection)
            {
                string str = "";
                
                foreach (DataColumn col in dataTable.Columns)
                {
                    str += item.Cells[col.ToString()].Value + "  ";
                  
                }
                label1.Text += "\n" + str;
            }
      
