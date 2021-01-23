    public Kunde(string name, string anschrift, string mail)
    {
        this.Anschrift = anschrift;
        this.eMail = mail;
        this.Name = name;
        this.OwnedProducts = new Produkte();
    }
