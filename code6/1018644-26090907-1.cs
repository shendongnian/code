    @model MyVM
    ....
    if (Model.IsMultipleChoice)
    {
      for(int i = 0; i < Model.Answers.Count; i++)
      {
        @Html.HiddenFor(m => m.Answers[i].ID)
        @Html.CheckBoxFor(m => m.Answers[i].IsSelected)
        @Html.LabelFor(m => m.Answers[i].IsSelected, Model.Answers[i].Name) // associate label with the checkbox
      }
    }
    else
    {
      foreach(var answer in Model.Answers)
      {
        @Html.RadioButtonFor(m => m.SelectedAnswer, @answer.ID)
        @Html.DisplayFor(m => m.Answers[i].Name)
      }
    }
