     public double GetMarks(List<Questionnaire> qList) {
            var AnsLibrary = GetAnswerLibrary();
            double result = 0;
            double TotalNumberofQuestion = qList.Count();
            int UserValidAnswer = 0;
            
            if(TotalNumberofQuestion >0) {
                var filterQuestionaire = qList.Where(q => q.UserAnsResponse != null).ToList();
                foreach (var q2 in filterQuestionaire) {
                    bool checkOnlyAnswerQuestion = AnsLibrary.Any(x => x.Question.QuestionId == q2.QuestionId);
                    if(checkOnlyAnswerQuestion) {
                    string city = (q2.UserAnsResponse).Trim();
                    string city2 = AnsLibrary.Where(x => x.Question.QuestionId == q2.QuestionId).Select(t => t.AnswerText).SingleOrDefault().Trim();
                    
                        bool checkuserAnswer = (city == city2) ;
                        if(q2.isCorrectAnswer == true && checkuserAnswer == true){
                            UserValidAnswer++;
                        }
                        if(q2.isCorrectAnswer == false && checkuserAnswer == false) {
                            UserValidAnswer++;
                        }
                    }
                }
                result = UserValidAnswer / TotalNumberofQuestion * 100;
            }
            return result;
        }
