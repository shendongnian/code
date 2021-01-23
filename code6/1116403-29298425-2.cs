    @model RecipeVM
    @using (Html.BeginForm())
    {
      @Html.LabelFor(m => m.Name)
      @Html.TextBoxFor(m => m.Name)
      @Html.ValidationMessageFor(m => m.Name)
      for (int i = 0; i < Model.SelectedIngredients.Count; i++)
      {
        @Html.LabelFor(m => m.SelectedIngredients[i])
        @Html.DropDownListFor(m => m.SelectedIngredients[i], Model.IngredientList, "-Please select-")
      }
    }
