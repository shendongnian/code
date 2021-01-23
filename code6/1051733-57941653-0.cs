    public MainForm()
            {
                InitializeComponent();
            }
    
    public void form2_UpdateEventHandler(object sender, Form2.UpdateEventArgs args)
        {
            dgvItems.DataSource = GetData();
        }
    private void MainForm_Load(object sender, EventArgs e)
            {
                 dgvItems.DataSource =  GetData();
            }
    public DataTable GetData()
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = *your query*
                adp = new SqlDataAdapter(cmd);
                ds.Clear();
                adp.Fill(ds);
                dt = ds.Tables[0];
                con.Close();
                return dt;
            } 
    //show Form 2
    
    private void btnSave_Click(object sender, EventArgs e)
            {
                Form2 frm = new Form2(this);
                frm.UpdateEventHandler += form2_UpdateEventHandler;
                frm.ShowDialog();
    
            }
