        public class AnswerObj{
    
           public string Answer{get;set;}
     
        }
    
        public class QuestionObj{
    
           public string Question {get;set;}
    
           public int CorrectAnswer {get;set;}
          
           public List<AnswerObj> Answers {get;set;}
        }
    
        public class QuestionsRepository
        {
           public List<QuestionObj> Questions {get;set;}
        }
    
        //Here is the code for reading your JSON
        string json = "Your_JSON_COMES_HERE as a string"
    
        QuestionsRepository questions = JsonConvert.DeserializeObject<QuestionsRepository>(json);
