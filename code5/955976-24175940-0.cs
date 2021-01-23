    PracticeConductViewModel pcvm = new PracticeConductViewModel();
                pcvm.Categories = (from x in _repository.GetAll<ReviewCategory>()
                                   where x.include == true &&
                                   ((x.AuditQuestionGroupId != null ? x.AuditQuestionGroupId : 0) == this.LoggedInEntity.AuditQuestionGroupId)
                                   from y in x.Questions
                                   where y.include == true                               
                                   group x by new { x, x.id, x.name, x.order } into newGroup
                                   orderby newGroup.Key.order != null ? 999 : newGroup.Key.order, newGroup.Key.name
                                   select new PracticeConductCategoriesViewModel
                                   {
                                       Id = newGroup.Key.id, // The categoryId
                                       name = newGroup.Key.name, // The category name
                                       order = newGroup.Key.order, // The order
                                       Evaluation1 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourEvaluation == 1 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Evaluation2 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourEvaluation == 2 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Evaluation3 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourEvaluation == 3 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Evaluation4 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourEvaluation == 4 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       EvaluationNR = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourEvaluation == 0 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Response1 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourResponse == 1 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Response2 = (from a in newGroup.Key.x.Questions
                                                      from b in a.Answers
                                                      where b.yourResponse == 2 && b.entityId == this.LoggedInEntity.EntityId
                                                      select a).Count(),
                                       Response3 = (from a in newGroup.Key.x.Questions
                                                    from b in a.Answers
                                                    where b.yourResponse == 3 && b.entityId == this.LoggedInEntity.EntityId
                                                    select a).Count(),
                                       //Percentage = newGroup.Key.yourEvaluation // Percentage of yourEvaluations answered for each question
                                   })
                                   .ToList();
    
    
                return View(pcvm);
