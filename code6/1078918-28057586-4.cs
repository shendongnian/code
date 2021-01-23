     @for (int i = 0; i < Model.GeneralQuestions.Count; i++)
     {
         var question = Model.GeneralQuestions[i];
         @Html.Label(question.QuestionString)
         <br />
         foreach (var answer in question.PossibleAnswers)
         {
             @Html.RadioButtonFor(model => 
               Model.GeneralQuestions[i].SelectedAnswerId, answer.Id)
             @Html.Label(answer.Answer)
             <br />
         }
     }
