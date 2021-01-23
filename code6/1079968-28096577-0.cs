    if(subject.Name == null)
                    {
                        **//EXCEPTION IS HERE!**
                        results.Question = context.Questions.SingleOrDefault(q => q.ID == question.ID).Text;
                    }
