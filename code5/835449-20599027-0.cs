    protected void add_Click(object sender, EventArgs e)
    {
        string insertStmt = "INSERT INTO dbo.ROUTE([FROM], [TO], MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY, FARE, MAPLINK) " +
                            "VALUES(@From, @To, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, @Sunday, @Fare, @Maplink)";
                            
        using (SqlConnection con = new SqlConnection("Data Source=JIHAD-PC;Initial Catalog=OBTRS;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand(insertStmt, con))
        {
            // fill the parameters
            cmd.Parameters.Add("@From", SqlDbType.Varchar, 50).Value = DropDownList1.SelectedIndex.ToString();
            cmd.Parameters.Add("@To", SqlDbType.Varchar, 50).Value = DropDownList2.SelectedIndex.ToString();
            cmd.Parameters.Add("@Monday", SqlDbType.Int).Value = monday;
            cmd.Parameters.Add("@Tuesday", SqlDbType.Int).Value = tuesday;
            cmd.Parameters.Add("@Wednesday", SqlDbType.Int).Value = wednesday;
            cmd.Parameters.Add("@Thursday", SqlDbType.Int).Value = thursday;
            cmd.Parameters.Add("@Friday", SqlDbType.Int).Value = friday;
            cmd.Parameters.Add("@Saturday", SqlDbType.Int).Value = saturday;
            cmd.Parameters.Add("@Sunday", SqlDbType.Int).Value = sunday;
            cmd.Parameters.Add("@Fare", SqlDbType.Int).Value = fare;
            cmd.Parameters.Add("@Maplink", SqlDbType.VarChar, 100).Value = maplink.Text;
            // open connection, execute INSERT command, close connection
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    
