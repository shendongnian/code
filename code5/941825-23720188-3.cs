    [HttpPost]
    public ActionResult CreateComment(CommentViewModel model)
    {
        var comment = new Comment();
        comment.CommenterName = model.Name;
        // etc...
    }
