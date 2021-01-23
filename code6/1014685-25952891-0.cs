    ...
    public ActionResult SimplePost(PostData postData, bool isRichView = true)
    {
        ViewBag.IsRichView = isRichView;
        return View("SimplePost", postData);
    }
    public ActionResult VideoPost(PostData postData, bool isRichView = true)
    {
        ViewBag.IsRichView = isRichView;
        return View("VideoPost", postData);
    }
    ...
