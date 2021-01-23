    public ActionResult Wiki(string artistName)
    {
        var artist = MyContext.Artists.SingleOrDefault(x => x.Name == artistName);
        //now you have the artist you want.
    }
