    public Player (Player p)
    {
        FirstName = p.FirstName;
        LastName = p.LastName;
        for (int i=0; i<p.Equip.Length; i++)
        {
            this.Equip[i] = new Equipement(p.Equip[i]);
        }
    }
