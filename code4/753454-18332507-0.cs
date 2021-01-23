    public static string getName()
    {
        string result = "";    
        ConnectionStringSettings myConnectionString = ConfigurationManager.ConnectionStrings["LibrarySystem.Properties.Settings.LibraryConnectionString"];
        using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
        {
            myDatabaseConnection.Open();
            using (SqlCommand mySqlCommand = new SqlCommand("select Top 1 * from Setting Order By SettingID Desc", myDatabaseConnection))
            using (SqlDataReader sqlreader = mySqlCommand.ExecuteReader())
            {
                if (sqlreader.Read())
                {
                    result = sqlreader["Name"].ToString();
                }
            }
        }
        return result;
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = myMethods.getName();
    }
