            public static IEnumerable<MedicineComposition> GetAllByItem(Item i)
        {
            SqlConnection con = new SqlConnection(BaseDataBase.ConnectionString);
            SqlCommand com = new SqlCommand("sp_Get_ByItemID_MedicineComposition", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter pr = new SqlParameter("@ID", i.ID);
            com.Parameters.Add(pr);
            try
            {
                SqlDataReader rd;
                try
                {
                    con.Open();
                    rd = com.ExecuteReader();
                }
                catch { yield break;}
                while (rd.Read())
                {
                    MedicineComposition m = new MedicineComposition() { };
                    if (!(rd["ID"] is DBNull))
                        m.ID = Int32.Parse(rd["ID"].ToString());
                    if (!(rd["ComponentID"] is DBNull))
                        m.Component = Component.GetByID(Int32.Parse(rd["ComponentID"].ToString()));
                    m.Item = i;
                    yield return m;
                }
                rd.Close();
            }
            finally
            {
                con.Close();
            }
        } 
