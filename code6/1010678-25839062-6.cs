    @model YourAssembly.RegistrationViewModel
    ....
    @for(int i = 0; i < Model.Questions.Count; i++)
    {
      @Html.HiddenFor(m > m.Questions[i].ID) // for binding
      @Html.DisplayFor(m > m.Questions[i].Text)
      foreach(var answer in Model.Questions[i].PossibleAnswers)
      {
        @Html.RadioButtonFor(m => m.Questions[i].SelectedAnswer, answer.ID, new { id = answer.ID})
        <label for="@answer.ID">answer.Text</label>
      }
    }
