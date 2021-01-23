private void Bind_DD()
{
    DataTable dt = new DataTable();
    using(SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString))
    {
        con2.Open();
        SqlCommand cmd1 = new SqlCommand("SELECT  ID, PRJ_TITLE FROM myTable",con2);
        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
        sda.Fill(dt);
    }
    myDDL.DataSource = dt;
    myDDL.DataTextField = "PRJ_TITLE";
    myDDL.DataValueField = "ID";
    myDDL.DataBind();
}
