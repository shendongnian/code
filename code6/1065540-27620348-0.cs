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
        public void CreateNewBank(Bank bank) {
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
    }
