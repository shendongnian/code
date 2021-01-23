    using (var con = new SqlConnection(cns)) 
    {
        using(var inset = new SqlCommand("Insert into [Table] values(@name,@date,@res)", con))
        {
             inset.Parameters.Add("@name", SqlDbType.VarChar).Value = hrac.MenoHraca;
             inset.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today;
             inset.Parameters.Add("@res", SqlDbType.Int).Value = int.Parse(cas);
             con.Open();
             inset.ExecuteNonQuery();
        }
     }
