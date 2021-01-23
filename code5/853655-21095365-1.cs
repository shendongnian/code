    private void ParseXml(string responce) // respnce is xml string.
    {
        string transactionType = responce.JustAfter("<TransactionType>", "</TransactionType>");
        string userName = responce.JustAfter("<Username>", "</UserName>");
        string password = responce.JustAfter("<Password>", "</Password>");
        ResponceClass resClass = new RespnceClass()
        {
            Transaction = transactionType,
            UserName = userName,
            Password = password
        });
    }
