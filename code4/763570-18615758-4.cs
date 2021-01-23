    public void Delete(int id)
    {
        using (KiGaDBEntities db = new KiGaDBEntities())
        {
            Event event = db.Event.SingleOrDefault(e => e.EventID == id);
            if (event != null)
            {
                db.Event.Remove(event);
                db.SaveChanges();
            }
        }
    }
