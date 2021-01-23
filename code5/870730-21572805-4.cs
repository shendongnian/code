    public ViewResult Item(int id)
    {
        FoodContext db = new FoodContext();
        List<ImageComment> comments = (from user in db.TxtComments
                                       from ff in db.Logins
                                       where ff.username == user.username
                                       select new ImageComment
                                       { 
                                           ImageUrl = ff.imgurl, 
                                           Comment = user.txtcmt 
                                       }).ToList();
        ViewModel vm = new ViewModel{ ImageComments = comments };     
        return View("MyView", vm);
    }
