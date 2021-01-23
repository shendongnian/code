     @for (int i = 0; i < Model.GeneralQuestions.Count; i++)
     {
         var question = Model.GeneralQuestions[i];
         foreach (var answer in question.PossibleAnswers)
         {
             @Html.RadioButtonFor(model => Model.GeneralQuestions[i].SelectedAnswerId, false)
             @Html.Label(answer.Answer)
             <br />
         }
     }
