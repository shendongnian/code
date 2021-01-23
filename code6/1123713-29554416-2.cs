    @model UserVM
    @using(Html.BeginForm())
    {
      @Html.HiddenFor(m => m.ID)
      @Html.DisplayFor(m => m.Name)
      for(int i = 0; i < Model.Roles.Count; i++)
      {
        @Html.HiddenFor(m => m.Roles[i].ID)
        @Html.CheckBoxFor(m => m.Roles[i].IsSelected)
        @Html.LabelFor(m => m.Roles[i].IsSelected, Model.Roles[i].Name)
      }
      <input type"submit" />
    }
