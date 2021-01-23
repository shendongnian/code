    private void Form1_Load(object sender, EventArgs e)
        {
            DataTable StudentDataTable = new DataTable("Student");
    
            //perform this on the Load Event of the form
            private void AddColumns() 
            {
                StudentDataTable.Columns.Add("First_Int_Column", typeof(int));
                StudentDataTable.Columns.Add("Second_String_Column", typeof(String));
    
                this.dataGridViewDisplay.DataSource = StudentDataTable;
            }
        }
    
        //Save_Button_Event to save the form field to the table which is then bind to the TableGridView
        private void SaveForm()
            {
                StudentDataTable.Rows.Add(new object[] { textBoxFirst.Text, textBoxSecond.Text});
    
                dataGridViewDisplay.DataSource = StudentDataTable;
            }
