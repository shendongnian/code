        databaseserver ser = new databaseserver();
        SqlConnection con = new SqlConnection(ser.dbserver + "Initial Catalog=AirlinesDB;Integrated Security=True");
        con.Open(); 
        SqlDataAdapter citiesadp = new SqlDataAdapter("select city from cities",con);
        DataSet dset = new DataSet(); //Creating instance of DataSet
        citiesadp.Fill(dset,"cities");
        cmbfrom.DataSource = dset.Tables["cities"];
        cmbfrom.DisplayMember = "city";
        cmbfrom..ValueMember= "city";
        con.Close();
        SqlConnection con1 = new SqlConnection(ser.dbserver + "Initial Catalog=AirlinesDB;Integrated Security=True");
        con1.Open();
        SqlDataAdapter destcity = new SqlDataAdapter("select city from cities",con1);
        DataSet destset = new DataSet();
        destcity.Fill(destset,"cities");
        cmbdest.DataSource = destset.Tables["cities"];
        cmbdest.DisplayMember = "city";
        cmbdest..ValueMember= "city";
        con1.Close();
