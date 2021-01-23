    public ActionResult RenderPostMessage()
    {
        PostMessageViewModel postMessageViewModel = new PostMessageViewModel();
    
        // here you set as many values as you want to receive in the form post.
        ViewBag.SomeField = "Some Value";
    
        return PartialView("PostMessage", postMessageViewModel);
    }
    
