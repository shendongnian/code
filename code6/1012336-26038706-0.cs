      DataTable dt = new DstsTsble();
     public cashagree(DataTable d2){
       dt =d2;
     }
     and in the load of `cashagree_Load` I asign the datagridview datasoure 
      
       private void Cashagree_Load(object sender, EventArgs e)
        {
            if (dt.Rows[0].IsNull(dt.Columns[0]))
            {
                MessageBox.Show("There no primary key");
                Close();
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[7].Visible = false;// Iwantn't all the datatable so I diapple some Columns
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[4].Visible = false;
          
 
          }
