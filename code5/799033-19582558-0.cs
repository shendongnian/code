    private void Form1_Load(object sender, EventArgs e)  
            {  
                displayDataGridView();  
      
                DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();  
                Editlink.UseColumnTextForLinkValue = true;  
                Editlink.HeaderText = "Edit";  
                Editlink.DataPropertyName = "lnkColumn";  
                Editlink.LinkBehavior = LinkBehavior.SystemDefault;  
                Editlink.Text = "Edit";  
                dataGridView1.Columns.Add(Editlink);  
      
                DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();  
                Deletelink.UseColumnTextForLinkValue = true;  
                Deletelink.HeaderText = "delete";  
                Deletelink.DataPropertyName = "lnkColumn";  
                Deletelink.LinkBehavior = LinkBehavior.SystemDefault;  
                Deletelink.Text = "Delete";  
                dataGridView1.Columns.Add(Deletelink);  
      
            }
