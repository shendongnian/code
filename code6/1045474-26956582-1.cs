    public ActionResult Index()
    {
        CustomViewModel model = new CustomViewModel();
        model.ShortPosts = _postRepository.GetLast20().ToList();
        model.Tags = _tagsRepository.GetAll().ToList();
        return View(model);
    }
