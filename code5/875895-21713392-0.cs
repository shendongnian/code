    public Form1()
    {
        InitializeComponent();
    }
    private void WObutton_Click(object sender, EventArgs e)
    {
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Michael\Documents\Visual Studio 2012\Projects\WorkOrderTKv2\WorkOrderTKv2TestAccessdb.mdb";
        conn.Open();
        OleDbCommand cmmd = new OleDbCommand("INSERT INTO TestFC (TestFC) Values(?)", conn);
        if (conn.State == ConnectionState.Open)
        {
            cmmd.Parameters.Add("@Name", OleDbType.VarWChar, 20).Value = Name;
            try
            {
                cmmd.ExecuteNonQuery();
                MessageBox.Show("DATA ADDED");
                conn.Close();
            }
            catch (OleDbException expe)
            {
                MessageBox.Show(expe.Message);
                conn.Close();
            }
        }
        else
        {
            MessageBox.Show("CON FAILED");
        }
    }
