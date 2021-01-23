    protected void Page_Load(object sender, EventArgs e)
    {
        using (var conn = new MySqlConnection(/* Your connection string here */))
        {
            conn.Open();
            using (var cmd = new MySqlCommand("SELECT * FROM Pet", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DropDownList1.DataSource = reader;
                        DropDownList1.DataValueField = "Specie";
                        DropDownList1.DataTextField = "Specie";
                        DropDownList1.DataBind();
                    }
                }
            }
        }
    }
