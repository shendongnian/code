    @model NSCEngineering.Models.NRIAndCategoriesViewModel
    @using (Html.BeginForm())
    {
      ...
      for (int i = 0; i < Model.Tasks.Count; i++)
      {
        <div class="task">
          @Html.HiddenFor(m => m.Tasks[i].ID, new { @class = "id" })
          @Html.DisplayFor(m => m.Tasks[i].Name)
          @Html.DropDownListFor(m => m.Tasks[i].State, Model.StateList, new { @class = "state" })
          @Html.TextAreaFor(m => m.Tasks[i].Notes, new { @class = "notes" })
          @Html.DisplayFor(m => m.Tasks[i].Description)
        </div>
      }
      <input type="submit" value="Save" />
    }
