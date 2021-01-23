        public ViewResult Questions(int page = 1)
        {
            QuestionsListViewModelmodel = new QuestionsListViewModel
            {
                // we need to get all items till now to render again 
                Questions = repository.Questions
                                      .Take(page * PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = 25,
                    TotalItems = repository.Questions.Count()
                }
            };
            return View(model);
        }
