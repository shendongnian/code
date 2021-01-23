    string dbConn = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\SONY\\Desktop\\FinalYearProject\\FinalYear Project\\bin\\Debug\\housewife.mdf;Integrated Security=True;User Instance=True";
    void fill_Combo() { 
       SqlConnection conn = new SqlConnection(dbConn);
       try {
           conn.Open();
           string query = "Select * From Food";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds)
            combobox1.DataSourse = ds;
            combobox1.DisplayMember = "fieldname";
            combobox1.ValueMember = "fieldname";
       }
       catch(Exception ex){
           MessageBox.Show(ex.Message);
       }
    }
