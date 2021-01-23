    public void Counts_Add(Count count)
    {
        if (db.Counts.Any(m => m.CountID == count.CountID))
        {
            Count c = db.Counts.Local.Where(m => m.CountID == count.CountID).FirstOrDefault();
            if ( c!= null ) {
                ((IObjectContextAdapter)db).ObjectContext.Detach(c);
            }
            db.Entry(count).State = System.Data.EntityState.Modified;
        }
        else
        {
            db.Counts.Add(Count);
        }
    }
