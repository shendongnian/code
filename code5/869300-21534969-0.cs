    private void Bind_DD()
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        SqlConnection con2 = new SqlConnection(strConnString);
        
        DataSet ds = new DataSet();
        SqlCommand cmd1 = new SqlCommand("SELECT  ID, PRJ_TITLE FROM myTable");
        cmd1.Connection = con2;
        con2.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
        sda.Fill(ds);
        myDDL.DataSource = ds; //cmd1.ExecuteReader();
        myDDL.DataTextField = "PRJ_TITLE";
        myDDL.DataValueField = "ID";
        myDDL.DataBind();
        con2.Close();
        //myDDL.DataBind(); 
}
