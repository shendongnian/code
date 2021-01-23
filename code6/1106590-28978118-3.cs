    public void EditFavorite(int id, Search editFavorite)
        {
            db.Entry(editFavorite).State = EntityState.Modified;
        }
    public void Save()
    {
        db.SaveChanges();
    }
