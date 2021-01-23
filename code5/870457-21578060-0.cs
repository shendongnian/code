    @if (Model != null && Model.Functions != null)
    {
       for (int i = 0; i < Model.Functions.Count; i++)
       {
          var fcn = Model.Functions[i];
          for (int j = 0; j < fcn.Actions.Count; j++)
          {
              @Html.CheckboxFor(model => Model.Functions[i].Actions[j].HasChecked);
              @Html.DisplayFor(model => fcn.Actions[j]);
          }
       }
     }
