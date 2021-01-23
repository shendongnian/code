    public class QuestionDto
    {
    
      public int id {get; set;}
      //put here getter and setter for all other Question attributes you want to have
    
      public QuestionDto(Question question){
        this.id = question.id;
        ... and so on
      }
    }
