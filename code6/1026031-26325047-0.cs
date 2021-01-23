    public ActionResult Index(ShortPostInfo m)
    {
        var top20 = PostRepository.GetLast20();
        var tag = PostRepository.GetTags();
        return View(new IndexModel { Top20 = top20, Tags = tag });
    }
