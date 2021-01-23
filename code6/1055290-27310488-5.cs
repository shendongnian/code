    @model List<QuestionVM>
    @using(Html.BeginForm())
    {
      for(int i = 0; i < Model.Count; i++)
      {
        @Html.HiddenFor(m => m[i].ID)
        @Html.DisplayFor(m => m[i].Text)
        foreach(AnswerVM answer in Model[i].AnswerList)
        {
          string id = "answer" + answer.ID; 
          @Html.RadioButtonFor(m => m[i].SelectedAnswer, answer.ID, new { id = @id })
          <label for="@id">@answer.Text</label>
        }
      }
      <input type="submit" value="Save" />
    }
