    public void EditFavorite(Search editFavorite)
    {
        db.Entry(editFavorite).State = EntityState.Modified;
    }
    public void Save()
    {
        db.SaveChanges();
    }
	
	public bool SearchExists(int id)
    {
        return db.Search.Count(e => e.Id == id) > 0;
    }
