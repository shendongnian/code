    //Define the class to hold the Tite property  values.
    public class RepeaterTitle
    {
         public string Title { get; set; }
    }
   
      string strConnString = ConfigurationManager.ConnectionStrings["LgnConnectionString"].ConnectionString;
        string str;
        SqlCommand com;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "select top 5 Title from table ORDER BY Datetime DESC";
        com = new SqlCommand(str, con);
        SqlDataReader reader;
        reader = com.ExecuteReader();
        List<RepeaterTitle> TitleLIst = new List<RepeaterTitle>();
        while (reader.Read())
        {
            RepeaterTitle oTitle = new RepeaterTitle();
            oTitle.Title = reader.GetValue(0).ToString();
            TitleLIst.Add(oTitle);
        }
        article_rep.DataSource = TitleLIst;
        article_rep.DataBind();
        con.Close();
