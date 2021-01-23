     public ActionResult Index(int? page)
        {
            var question = (from e in db.Ques
                            select new
                            {
                                QuestionId = e.QuestionId,
                                QuestionName = e.QuestionName
                            }).ToList()
                          .Select(x => new QuestionViewModel()
                          {
                              QuestionId = x.QuestionId ,
                              QuestionName = x.QuestionName
                          });
            
                int pageSize = 2;
                int pageNumber = (page ?? 1);
                return View(question.ToPagedList(pageNumber, pageSize));
                   
        }
