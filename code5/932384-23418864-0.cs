    bool dbWorks = false;
    sting cs = "Data Source=KIETH\\SQLEXPRESS;Initial Catalog=Corsit;Trusted_Connection=Yes";
    using (SqlConnection conn = new SqlConnection(cs))
    {
        try
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                dbWorks = true;
            }
        }   
    }
    
