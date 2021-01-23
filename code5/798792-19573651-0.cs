    if (TransactionList == null)
       TransactionList = new List<Transaction>();
    
    for (int i = 0; i < (lines / 5); i++)
            {
                TransactionList.Add(new Transaction //Error happens on this line
                {
                    TotalEarned = Convert.ToDouble(stringArray[(i * 5)]),
                    TotalCost = Convert.ToDouble(stringArray[(i * 5) + 1]),
                    TotalHST = Convert.ToDouble(stringArray[(i * 5) + 2]),
                    Category = stringArray[(i * 5) + 3],
                    DaysSince2013 = Convert.ToInt32(stringArray[(i * 5) + 4])
                });
            }
