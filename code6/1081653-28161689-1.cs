    @model List<RoleDetail>
    @using(Html.BeginForm())
    {
      for(int i = 0; i < Model.Count; i++)
      {
        @Html.HiddenFor(m => m.ControllerName) // needed for postback
        @Html.DisplayFor( => m.ControllerName)
        @Html.CheckBoxFor(m => m.IsCreate)
        ....
      }
      <input type="submit" />
    }
