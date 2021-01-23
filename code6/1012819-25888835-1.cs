    @model YourAssembly.ExamVM
    @using (Html.BeginForm())
    {
      @Html.HiddenFor(m => m.ID)
      @Html.DisplayFor(m => m.Name)
      for (int i = 0; i < Model.Questions; i++)
      {
        @Html.HiddenFor(m => m.Questions[i].ID)
        @Html.CheckBoxFor(m => m.Questions[i].IsSelected)
        @Html.DisplayFor(m => m.Questions[i].Name)
      }
      <input type="submit" value="Save" />
    }
