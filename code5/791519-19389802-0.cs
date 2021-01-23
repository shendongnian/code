    [WebService(Namespace = "example.org")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService : System.Web.Services.WebService
    {
        // 1
        const string constring = "Database=transaction;server=localhost;user=sa;password=toon2255";
        [WebMethod(Description = "Transaction")]
        public string transaction(int userid, int amount)
        {
            // 2
            using (SqlConnection conn = new SqlConnection(constring))
            {
                conn.Open();
                // 3
                using (SqlCommand comm2 = new SqlCommand("INSERT INTO moneytrans VALUES(@userid,@amount)"))
                {
                    comm2.Parameters.AddWithValue("@userid", userid);
                    comm2.Parameters.AddWithValue("@amount", amount);
                    
                    // 4
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        comm2.Transaction = trans;
                        try
                        {
                            comm2.ExecuteNonQuery();
                            trans.Commit();
                            return "Transaction Completed. ";
                        }
                        // 5
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            // 6
                            return string.Format("Transaction Failed: {0}", ex);
                        }
                        // 7
                        //finally Not needed because of using block
                        //{
                        //    conn.Close();
                        //}
                    }
                }
            }
        }
    }
