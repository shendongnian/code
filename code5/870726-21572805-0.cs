    public class FoodAndCommentsViewModel
    {
        public List<FoodItems> FoodItems { get; set; }
        public List<TxtComments> Comments { get; set; }
        public ViewModel()
        {
            FoodItems = new List<FoodItems>();
            TxtComments = new List<TxtComments>();
        }
    }
    public ViewResult Item(int id)
    {
        FoodAndCommentsViewModel vm = new FoodAndCommentsViewModel();
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
