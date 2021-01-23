    private void Form1_Load(object sender, EventArgs e)  
            {  
                displayDataGridView();  
      
                DataGridViewButtonColumn EditBtn = new DataGridViewButtonColumn();
                EditBtn.HeaderText = "Edit";
                EditBtn.Text = "Edit";
                EditBtn.Name = "EditBtn";
                EditBtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(EditBtn);  
      
                DataGridViewButtonColumn DeleteBtn = new DataGridViewButtonColumn();  
                DeleteBtn.HeaderText = "Delete";  
                DeleteBtn.Name = "DeleteBtn";
                DeleteBtn.Text = "Delete";  
                DeleteBtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(DeleteBtn);  
      
            }
