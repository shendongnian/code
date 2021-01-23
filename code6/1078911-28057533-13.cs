    @model YourAssembly.StudentVM
    @using(Html.BeginForm())
    {
      @Html.HiddenFor(m => m.ID)
      @Html.DisplayFor(m => m.Name)
      for(int i = 0; i < Model.Subjects.Count; i++)
      {
        @Html.HiddenFor(m => m.Subjects[i].ID)
        @Html.DisplayFor(m => m.Subjects[i].Name) // will display "General" if no name
        for (int j = 0; j < Model.Subjects[i].Questions.Count; j++)
        {
          @Html.HiddenFor(m => m.Subjects[i].Questions[j].ID)
          @Html.DisplayFor(m => m.Subjects[i].Questions[j].Text)
          foreach(var answer in Model.Subjects[i].Questions[j].PossibleAnswers )
          {
            <div>
              @Html.RadioButtonFor(m => m.Subjects[i].Questions[j].SelectedAnswer, answer.ID, new { id = answer.ID})
              <label for="@answer.ID">@answer.Text</label>
            </div>
          }
          @Html.ValidationMessageFor(m => m.Subjects[i].Questions[j].SelectedAnswer)
        }
      }
      <input type="submit" value="save" />
    }
