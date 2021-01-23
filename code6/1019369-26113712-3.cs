    public ActionResult PostComment()
    {
        var vModel = new CreateViewModel();
        vModel.Comments = comrepository.GetAllComments().ToList();
        
        // loop through vModel.Comments
        foreach (var com in vModel.Comments)
        {
            vModel.Replies = replyrepository.GetReplybyID(com.Id);
        }
        return View(vModel); 
    }
