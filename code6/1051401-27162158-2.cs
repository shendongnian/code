    @model MyModelVM
    @using (Html.BeginForm())
    {
      for(int i = 0; i < Model.Groups.Count; i++)
      {
        @Html.HiddenFor(m => m.Groups[i].ID)
        @Html.CheckBoxFor(m => m.Groups[i].IsMember)
        @Html.LabelFor(m => m.Groups[i].DisplayName)
      }
      <input type="submit" value="Update groups" />
    }
