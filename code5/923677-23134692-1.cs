    public void DeleteMed(int medid)
    {
       meds med = db.meds.Find(medid);
       db.meds.Remove(med);
       db.SaveChanges();
    }
