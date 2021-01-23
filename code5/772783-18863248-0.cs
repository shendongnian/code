    foreach (var item in myMoney)
        Console.WriteLine("amount is {0}, and type is {1}", item.amount, item.type);
    for (int i = 0; i < myMoney.Count; i++)
        Console.WriteLine("amount is {0}, and type is {1}", myMoney[i].amount, myMoney[i].type);
    myMoney.ForEach(item => Console.WriteLine("amount is {0}, and type is {1}", item.amount, item.type));
