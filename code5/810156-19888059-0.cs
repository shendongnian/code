    Map = transactions => from transaction in transactions
    select new
        {
            Description = new object[] { transaction.Description, transaction.Items.Select(i => i.Name), transaction.Documents.Select(i => i.Name) },
            Account_UserName = transaction.Account.UserName,
            Month = transaction.Time.Month + "/" + transaction.Time.Year, // To be able to group on Months
            Time = transaction.Time
        };
