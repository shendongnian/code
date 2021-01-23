     public DataTable Uzmi()
            {
                DataTable dt;
                dt = new DataTable();
                SqlCommand sc = new SqlCommand();
                try
                {
                    sc.CommandText = "SELECT * FROM KategorijaLeka";
                    sc.Connection = pokreniDBTransakciju();
                    SqlDataReader reader;
                    reader = sc.ExecuteReader();
    
                    dt.Load(reader);
                    cn.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("GRESKA!!!" + e);
                    return null;
                }
                return dt;
            }
