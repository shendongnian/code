    public Bank(string bn, string scode)
        {
            name = bn;
            sortcode = scode;
        }
        public string name { get; set; } // textbox6
        public string sortcode { get; set; } // textbox5
    }
    class BankDataService
    {
        public void SaveNewBankToDatabase(Bank bank) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
            {
                string sqlQuery = (@"INSERT INTO [Bank] (BankName, SortCode)
                                VALUES (@BankName, @SortCode)");
                connection.Open();
    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("BankName", bank.name);
                    command.Parameters.AddWithValue("SortCode", bank.sortcode);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateBankToDatabase(Bank bank) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
            {
                string sqlQuery = (@"UPDATE [Bank]
                                   SET SortCode=@SortCode
                                   WHERE @BankName=@BankName");
                connection.Open();
    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("BankName", bank.name);
                    command.Parameters.AddWithValue("SortCode", bank.sortcode);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void SelectBankFromDatabase(string bankName) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString))
            {
                string sqlQuery = (@"SELECT BankName, SortCode FROM [Bank] WHERE BankName=@BankName");
                connection.Open();
    
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("BankName", bank.name);
                    using(var reader = command.ExecuteReader()) {
                         if(reader.Read()){
                              return new Bank { BankName=reader["BankName"].ToString(), SortCode=reader["SortCode"].ToString(); }
                         }
                    }
                }
                return null;
            }
        }
    }
