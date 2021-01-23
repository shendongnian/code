    public void EditFavorite(Search editFavorite)
    {
        db.Entry(editFavorite).State = EntityState.Modified;
    }
    public void Save()
    {
        db.SaveChanges();
    }
