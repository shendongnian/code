        using (var context = new SyntheticData.EF.DBContext())
        {
            var item = (from t in context.TEMPLATEs
                            .Include("DATASET")
                            .Include("COLUMNs")
                            .Include("SORTs")
                            .Include("FILTERs")
                        where t.USERID == identityname && t.ID == id select t).FirstOrDefault();
            return item;
        }
