    for(int i = 0; i < Model.Count; i++) {
    {
      
      if (@Model[i].MultipleChoice)
      {
        // Radio buttons for multiple choice
        foreach(string option in Model[i].PossibleAnswers)
        {
          <label>   
            @Html.RadioButtonFor(m => m[i].Response, option})
            <span>@option</span>
          </label>
        }
      }
      else
      {
        // Textbox for answer
        @Html.TextBoxFor(m => m[i].Response)
      }
    }
