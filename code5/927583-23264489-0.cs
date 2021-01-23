    using System.Data;    
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter(Query, connection);
    sda.Fill(dt);
    int sum=Convert.ToInt32(dt.Compute("sum(Price)",""));
