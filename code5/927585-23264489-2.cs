    using System.Data;    
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter("Select Price from PriceList", connection);
    sda.Fill(dt);
    int sum=Convert.ToInt32(dt.Compute("sum(Price)",""));
    Label1.Text=sum.ToString();
