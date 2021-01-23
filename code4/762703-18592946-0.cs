        public void filldropdown()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "select * from category";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds);
            DropDownList DropDownList1 = new DropDownList();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0,new ListItem("---select---", "null"));
            conn.Close();
        }
