    //CellValueChanged event handler for your dataGridView1
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e){ 
      var col = dataGridView1.Columns[e.ColumnIndex];
      if(col.Name == "column2" || col.Name == "column3") {
        //update the column4
        dataGridView1[dataGridView1.Columns["column4"].Index, e.RowIndex].Value = 
        dataGridView1[dataGridView1.Columns["column2"].Index, e.RowIndex].Value *
        dataGridView1[dataGridView1.Columns["column3"].Index, e.RowIndex].Value;
      }         
    }
    //use this method to initialize all the values for the `column4`, this will be done only
    //once in ,for example, your Form constructor
    private void InitColumn4(){
       foreach(DataGridViewRow row in dataGridView1.Rows){
         if(row.IsNewRow) continue;
         row.Cells["column4"].Value = row.Cells["column2"].Value * row.Cells["column3"].Value;
       }
    }
    //call it in your form constructor
    public Form1(){ 
       InitializeComponent();
       //init data for your grid first
       //...
       InitColumn4();
    }
