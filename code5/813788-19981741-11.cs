    public ActionResult SentMessages(){
        using(DataContext db = new DataContext()){
            var us = new UserService(db);
            return us.GetSentMessages(GetCurrentUserId());
        }
    }
