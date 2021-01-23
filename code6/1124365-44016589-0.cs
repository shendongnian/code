    static void Main(string[] args)
            {
                SqlConnection sqlCon = new SqlConnection("Removed");
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("Select * from Table", sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                string csv=reader.ToCSVHighPerformance(true);
                File.WriteAllText("Test.CSV", csv);
                reader.Close();
                sqlCon.Close();
            }
