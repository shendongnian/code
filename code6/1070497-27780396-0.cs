    class Question {
     private Dictionary<string, Question> questions = ...
     public Question Show(){
         // ... display
         var selectedOption = GetSelected();
         // questions["abc"] = Q2
         var next = questions[selectedOption];
    
         if(next != null)
             next.SetValue(selectedOption);
    
         return next;
    }
