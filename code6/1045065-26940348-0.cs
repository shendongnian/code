    public ActionResult ListAll()
    {
        List<Album> albums = new List<Album>();
        using (newsDBEntities context = new newsDBEntities())
        {
            albums = context.Albums.ToList();
    
            var i = albums.First().Images.Take(3).ToList();
            return View(albums);
        }
    }
