    public SqlDataAdapter sda { get; set; }
    public DataSet ds { get; set; }    
    public Form2()
        {
           InitializeComponent();
           sda = new SqlDataAdapter("select * from testTable where name = 'test'",connection_string);
                ds=new DataSet();
                dataGridView1.DataSource = ds;
        }
        private void Update_Click(object sender, EventArgs e)
        {
            sda.Update(ds);
        }
