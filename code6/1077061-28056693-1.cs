    class QuestionGroupQuestionPair {
       public Question_Group QuestionGroup {get;set;}
       public IEnumerable<Question_Group_Question> QuestionCollection {get;set;}
    }
    IEnumerable<QuestionGroupQuestionPair> query = from qg in this.Question_Group
    select new QuestionGroupQuestion() 
        { 
           QuestionGroup = qg,
           QuestionCollection = qg.Question_Group_Question.Where(qgq => qgq.Question.Removed_Flag == false) 
        }
