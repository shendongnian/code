                List<GetQuestionViewModel> quest = new List<GetQuestionViewModel>();
            foreach (var item in db.Questions.Where(q => q.PageNumber == page).OrderBy(q => q.QuestionRanking))
            {
                quest.Add(new GetQuestionViewModel()
                {
                    Id = item.Id,
                    QuestionOptions = db.QuestionOptions
                    .Where(k => k.QuestionId == item.Id)
                    .ToList(),
                   PageNumber = item.PageNumber,
                    Question1 = item.Question1,
                    QuestionRanking = item.QuestionRanking,
                    QuestionTypeId = item.QuestionTypeId
                });
            }
            return View(quest);
