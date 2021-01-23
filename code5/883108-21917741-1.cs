        public ActionResult Index()
        {
            QuestionMainModel model = new QuestionMainModel();
            
            List<QuestionOptionViewModel> options = new List<QuestionOptionViewModel>();
            options.Add(new QuestionOptionViewModel(){ Id = 1, Text = "Ans1", Value = "1"});
            options.Add(new QuestionOptionViewModel(){ Id = 2, Text = "Ans2", Value = "2"});
            options.Add(new QuestionOptionViewModel(){ Id = 3, Text = "Ans3", Value = "3"});
            model.Questions = new List<QuestionViewModel>();
            model.Questions.Add(new QuestionViewModel() { Id = 1, Text = "Question1", Options = options });
            return View(model);
        }
