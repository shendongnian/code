       if (IsPostBack)
        {
            // if this line fails, then you don't have the proper connection string
            // element in the config file.
            Debug.Assert(ConfigurationManager.ConnectionStrings["StudConnection"] != null);
            SqlConnection studConnA = new SqlConnection(ConfigurationManager.ConnectionStrings["StudConnection"].ConnectionString);
            studConnA.Open();
            string checkuser = "select count(*) from StudTable where Name='" + TextBoxName.Text + "'";
            SqlCommand studComA = new SqlCommand(checkuser, studConnA);
            int temp = Convert.ToInt32(studComA.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Response.Write("User already Exists");
            }
            studConnA.Close();
        }
