    public static List<Compte> getXmlComptes(XElement n)
    {
       if (n == null)
           throw new ArgumentNullException("Something is null");
        var comptes = from k in n.Elements("Konto")
                      select new Compte
                      {
                          NumCompte = (string)k.Element("KtoNr"),
                          typeCompte = (string)k.Element("KontoArt"),
                          DateOuverture = (string)k.Element("KtoOeff"),
                          IBAN = (string)k.Element("IBAN"),
                          Devise = (string)k.Element("Waehrung"),
                          CommentairesCompte = (string)k.Element("Kommentar"),
                          Trans = getXmlTransactions(k)
                      };
        return comptes.ToList();
    }
