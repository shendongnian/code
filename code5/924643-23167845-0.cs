        string constr = Properties.Settings.Default.Subject_1ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand com = new SqlCommand("SELECT * from Subject_Title WHERE Date BETWEEN \"01-03-14\" and \"01-04-14\" ", conn);
        conn.Open();       
        SqlDataReader reader =com.ExecuteReader();
        while(reader.read()){
        this.labeltext += " " + reader.GetString(0);       //Use column ordinal for Date
        this.labeltext += " " + reader.GetString(1)+" ";   //Use column ordinal for Subject
        }
        conn.Close()
        this.label1.Text = this.labeltext;
