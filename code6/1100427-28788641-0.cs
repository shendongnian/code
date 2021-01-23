    public partial class FamilyTree : UserControl
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Hannes\Documents\Visual Studio 2013\Projects\fam\fam\Prog.mdb";
        public FamilyTree()
        {
            InitializeComponent();
        }
        private void FamilyTree_Load(object sender, System.EventArgs e)
        {
        }
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string title = txtID.Text.ToString();
            sqlQuery = "SELECT * FROM FamilyTree WHERE Title = ?";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Title", title);
                    conn.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtSex.Text += dr["gendre"].ToString();
                        txtColour.Text += dr["name"].ToString();
                        txtDOB.Text += dr["DOB"].ToString();
                        txtStatus.Text += dr["city"].ToString();
                        txtCock.Text += dr["mom"].ToString();
                        txtHen.Text += dr["dad"].ToString();
                    }
                }
            }
        }
    }
