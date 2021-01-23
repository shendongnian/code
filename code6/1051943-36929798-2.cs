     [WebMethod]
            public static List<ChartDetails> GetDataonload()
            {
                string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
                using (SqlConnection con = new SqlConnection(Constring))
                {
    
                    List<ChartDetails> dataList = new List<ChartDetails>();
                    SqlCommand cmd = new SqlCommand("Usp_TotalcountCPA_new_usingfunction", con);
                    cmd.CommandTimeout = 50;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iAdvertiserid", "1000120");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
    
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        ChartDetails details = new ChartDetails();
                        string date = dtrow[4].ToString();
                        details.date = date.Substring(3, 7);
                        details.cpacount = dtrow[7].ToString();
                        details.cpicount = dtrow[10].ToString();
                        details.cpmcount = dtrow[14].ToString();
                        details.cvpcount = dtrow[16].ToString();
                        dataList.Add(details);
                    }
                    return dataList;
                }
            }
            public class ChartDetails
            {
                public string date { get; set; }
                public string cpacount { get; set; }
                public string cpicount { get; set; }
                public string cpmcount { get; set; }
                public string cvpcount { get; set; }
                // public string CountryCode { get; set; }
            }
    
