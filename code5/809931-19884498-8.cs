    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                MySqlConnection connStr = new MySqlConnection();
                connStr.ConnectionString = "Server = localhost; Database = healthlivin; Uid = root; Pwd = khei92;"; PesronIDB
                //Change query to include PersonIDB               
                String searchOverall = "SELECT P.PersonID, P.PersonName, P.Email, P.Picture, CF.PersonIDB FROM Person P LEFT JOIN contactFriend  CF ON P.PersonID = CF.PersonID";
                MySqlCommand cmdSearch = new MySqlCommand(searchOverall, connStr);
                connStr.Open();
                MySqlDataReader dtrRead2 = cmdSearch.ExecuteReader();
                friendRepeater.DataSource = dtrRead2;
                friendRepeater.DataBind();
                dtrRead2.Close();
                dtrRead2 = null;
                connStr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }            
        }             
    }
