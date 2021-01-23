    public ActionResult PostComment()
    {
        var vModel = new CreateViewModel();
        vModel.Comments = comrepository.GetAllComments().ToList();
        
        // loop through vModel.Comments
        for (int i = 0; i < vModel.Comments.Count; i++)
        {
            vModel.Replies = replyrepository.GetReplybyID(vModel.Comments[i].Id).ToList();
        }
        return View(vModel); 
    }
