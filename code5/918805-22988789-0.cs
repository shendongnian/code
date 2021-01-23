    class BankAccountModel
    {
      public string AccountNumber { get; set; }
      public string AccountName { get; set; }
      public string Bank { get; set; }
      public string AccountType { get; set; }
      public static BankAccountModel GetAccount(string accountNumber)
      {
        var account = new BankAccountModel()
        {
          AccountNumber = accountNumber,
        };
        using (SqlConnection newCon = new SqlConnection(db.GetConnectionString))
        {
            ...
            account.AccountName = rdr.GetString(1);
            account.Bank = rdr.GetString(2);
            account.AccountType = rdr.GetString(3);
        }
        return account;
      }
    }
