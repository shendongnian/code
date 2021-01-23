    public static int FetchProductCountByDayOfWeek(DayOfWeek dayOfWeek)
    {
        using(SqlConnection con = new SqlConnection(Settings.DatabaseConnectionString))
        {
             con.Open();
             
             SqlCommand com = new SqlCommand("Select * from tblProducts where Day_Of_Week = @day_of_week");
             com.CommandType = CommandType.Text;
             com.Connection = con;
               
             com.Parameters.AddWithValue("@day_of_week", dayOfWeek.ToString());
        
             using (SqlDataAdapter da = new SqlDataAdapter(com))
             {
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return Convert.ToInt32(dt.Rows[0]["Product_Count"]);
             }
        }
    }
