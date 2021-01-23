    DAL.VindjekindjeDataContext dc = new DAL.VindjekindjeDataContext();
      
    public bool GetCompleteOuder(out DAL.TOUD  user, string p)
    {
        user = new DAL.TOUD();
        try
        {
            dc.TOUDs.SingleOrDefault(t => t.Voornaam == p);
            user = (from TOUD in dc.TOUDs where TOUD.Voornaam.Equals(p) select TOUD).Single();
            return true;
        }
        catch
        {
            return false;
        }
    }
