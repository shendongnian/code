    string s = TextBox1.Text;
    int i;
    if(Int32.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out i))
    {
       using(SqlConnection con = new SqlConnection("YourConnectionString"))
       {
          using(SqlCommand cmd = new SqlCommand())
          {
             cmd.CommandText = "Update TableName SET Current_balance = Current_balance + @p";
             cmd.Connection = con;
             cmd.Parameters.AddWithValue("@p", i);
             con.Open();
             cmd.ExecuteNonQuery();
          }
       }
    }
    else
    {
       //TextBox string is not a valid integer.
    }
