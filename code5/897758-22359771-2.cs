    public class PagedMalicious : Shared.Paged
    {
        public IEnumerable<MaliciousSmall> MaliciousCode
        {
            get
            {
                using (var conn = new SqlConnection("<my server connection>")) {
                    var cmd = new SqlCommand("SELECT name, number FROM myTable", conn);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var maliciousSmall = new MaliciousSmall {
                                Name = reader.GetString(0), 
                                Number = reader.GetInt32(1) 
                            };
                            yield return maliciousSmall;
                        }
                    }
                }
            }
        }
    }
