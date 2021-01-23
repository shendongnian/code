    if (Model.GroupOptions[i].ConfigOptionTypes[j].Type == ConfigOptionFieldType.String)
    {
      ....
      @Html.TextBoxFor(m => m.GroupOptions[i].ConfigOptionTypes[j].ConfigOptions[k].Value, new { @class = "m-wrap medium" })
      ....
    }
    else
    {
      @Html.HiddenFor(m => m.GroupOptions[i].ConfigOptionTypes[j].ConfigOptions[k].Value
    }
