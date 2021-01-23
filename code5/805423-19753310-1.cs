    List<DocumentRegistration> list= new List<DocumentRegistration>();
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString="YourConnectionString"
    conn.Open();
    SqlCommand cmd = new SqlCommand("Show_Data_ByTitle", conn);
    SqlCommand cmd = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("Title", "yourtitle"));
    SqlReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
        DocumentRegistration dr=new DocumentRegistration
        {
            DocNo =  Convert.ToInt32(reader["DocId"]);
            DocType =  Convert.ToString(reader["DocType"]);
            DocTitle = Convert.ToString(reader["DocTitle"]);
            RedDate = Convert.ToDateTime(reader["RedDate"]);
        }
        list.Add(dr);
    }
    //put this code where you want to load the list like PageLoad()
    GridView1.DataSource=list;
    GridView1.Databind();
