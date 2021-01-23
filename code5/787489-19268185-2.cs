    // Model for an answer ('Value' in your question
    public class Answer { ... }
    // Model for a question containing possible answers and the actual answer
    public class Question 
    { 
       private Answer _answer;
       public List<Answer> PossibleAnswers { get; set; }
       public Answer Answer { get; set; }
       public DateTime Changed { get; set; }
       
       public Question()
       {
           // Acquire the values from wherever
           PossibleAnswers = ...;
       }
    }
