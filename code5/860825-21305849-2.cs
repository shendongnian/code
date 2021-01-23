    public static List<Transaction> getXmlTransactions(XElement n)
    {
       if (n == null)
           throw new ArgumentNullException("Konto is null");
        var transactions = from t in n.Elements("Transaktion")
                           select new Transaction {
                               TransID = (string)t.Element("TransID"),
                               TypeTransaction = (string)t.Element("TransArt"),
                               DateEntree = (string)t.Element("BuchDat"),
                               Montant = (string)t.Element("BetragWAE"),
                               Devise = (string)t.Element("BuchDat"),
                               Pays = (string)t.Element("GegenLandText"),
                               AbreviationPays = (string)t.Element("GegenLand"),
                               autresinfo = (string)t.Element("Kommentar")
                           };
        return transactions.ToList();
    }
