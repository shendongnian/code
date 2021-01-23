    public ActionResult Create()
    {
      List<QuestionVM> model = new QuestionVM();
      // populate your questions and the possible answers for each question
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(List<QuestionVM> model)
    {
      // The model now contains the ID of each question and the ID of its selected answer
    }
