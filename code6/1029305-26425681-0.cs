    List<News> query = _db.News.ToList();
    public List<News> GetProduct(string filter) {
        if (filter == "DesDate") return query.OrderByDescending(u => ReleaseDate).ToList();
    
    }
