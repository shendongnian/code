    public static List<Transaction> getXmlTransactions(XElement konto)
    {
        return konto.Elements("Transaction")
                    .Select(t => new Transaction {
                         TransID = (string)t.Element("idTrans"),
                         TypeTransaction = (string)t.Element("type")
                    }).ToList();
    }
