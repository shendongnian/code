    if (!items.TryGetKey(transaction.ID1, out sAcc))
      items.Add(transaction.ID1, sAcc = new Account);
    if (!items.TryGetKey(transaction.ID2, out dAcc))
      items.Add(transaction.ID2, dAcc = new Account);
    // Your code.
