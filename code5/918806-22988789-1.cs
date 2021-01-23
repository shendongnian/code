    class BankAccountModel
    {
      public string AccountNumber { get; set; }
      public string AccountName { get; set; }
      public string Bank { get; set; }
      public string AccountType { get; set; }
    }
    class BankAccountRepository
    {
      public BankAccountModel GetAccount(string AccountNumber)
      {
        ...
      }
    }
