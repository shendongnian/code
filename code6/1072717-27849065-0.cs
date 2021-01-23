    public static TransList ChangeTrans(
        TransList copyTransList, string singleCitation, int citNumb) //add ConFee
    {
        TransList newTransList = new TransList();
        foreach (Transaction temp in copyTransList.OfType<TranID>())
        {
            Transaction newTransaction = new TranID();
            newTransaction.Value = temp.Value + "-" + citNumb;
            newTransList.Add(newTransaction);
        }
        foreach(Transaction temp in copyTransList.OfType<Comment2>())
        {
            Transaction newTransaction = new Comment2();
            newTransaction.Value = singleCitation;
            newTransList.Add(newTransaction);
        }
        return newTransList;
    }
