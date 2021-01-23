    public static List<Institute> GetInstitutions(long OrgID)
    {
        using (SchoolGapEntities1 Db = new SchoolGapEntities1())
        {
            return Db.Institutes.Where(I => I.INS_FK_ORGID == OrgID).ToList();
        }
    }
    
