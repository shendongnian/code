    using (SqlConnection cn = new SqlConnection())
    {
        cn.Open();
        using (SqlTransaction tr = cn.BeginTransaction())
        {
            //some code
            tr.Commit();
        }
    }
