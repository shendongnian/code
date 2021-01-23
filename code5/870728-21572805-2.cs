    public ViewResult Item(int id)
    {
        ViewModelvm = new ViewModel();
        FoodContext db = new FoodContext();
        var foodItems = db.FoodItems.Where(row => row.itemid == id);
        var comments = (from user in db.TxtComments
                        from ff in db.Logins
                        where ff.username == user.username
                        select new 
                               { 
                                   imgurl = ff.imgurl, 
                                   txtcmt = user.txtcmt 
                               }
                        );
             
        // Build ViewModel and return it to your view.
        vm.FoodItems = foodItems.ToList();
        vm.Comments = comments.ToList();
        return View("MyView", vm);
    }
