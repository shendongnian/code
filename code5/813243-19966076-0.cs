     using (DataDataContext _db = new DataDataContext())
     {
         foreach (VINPatternDecode vin in _db.VINPatternDecodes)
         {
             vin.DivisionName = GetMfgID(vin.DivisionName.Replace("~",""));
         }
        _db.SubmitChanges();
    }
