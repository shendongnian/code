    using (SqlConnection cn = new SqlConnection(...))
    {
        cn.Open();
        using (SqlCommand cmd = new SqlCommand("insert into ttt values (@testvalue)", cn))
        {
            cmd.Parameters.AddWithValue("@testValue", "r=DE'S'C@4593§$%");
            cmd.ExecuteNonQuery();
        }
    }
