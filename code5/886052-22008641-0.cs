    public class Report {    
        public static DataSet LoadReport(string candidate_val) {
            using (SqlCommand command = new SqlCommand("SELECT * From personal_information WHERE candidateNo = @candidate_val", myConn))
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@candidate_val",candidate_val);
                DataSet ds = new DataSet();
                da.Fill(ds, "personal_information");
                return ds;
            }
        }
    }
