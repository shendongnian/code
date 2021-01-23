    //Declare this variable     
        DateTimePicker dtp = new DateTimePicker();  //DateTimePicker  
        Rectangle _Rectangle;  
            
        public Form1()
        {
            InitializeComponent();
             
            dtp.Visible = false;  //  
            dtp.Format = DateTimePickerFormat.Custom;  
        }
        
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Value.ToString();  //
        }
        
        private void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }
    
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
                string sql = "SELECT * FROM database.table";
                dataAdapter = new MySqlDataAdapter(sql, connection);
                dataTable = new DataTable();
                connection.Open();
                dataAdapter.Fill(dataTable);
                connection.Close();
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["DATE"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == 2)  // here 2 is the date column in datagridview1
                {
                    dataGridView1.Controls.Add(dtp);  
                    dtp.Value =Convert.ToDateTime(dataGridView1.CurrentCell.Value.ToString());
                    dtp.CustomFormat = "dd/MM/yyyy";    // change the custom format here to display on the datetimepicker
                    dtp.TextChanged += new EventHandler(dtp_TextChange); //dtp_TextChange
                    dtp.Visible = true;  //  
    
    
                    _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
    
                    dtp.CloseUp+=new EventHandler(dtp_CloseUp);
                    
                }
                else
                    dtp.Visible = false;  
        }
    
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;  
        }
    
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;  
        }
