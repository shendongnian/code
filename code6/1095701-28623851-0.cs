    for (int i = 0; i < Model.Skills.Count; i++)
    {
      @Html.LabelFor(m => m.Skills[i].Selected)
      @Html.CheckBoxFor(m => m.Skills[i].Selected)
      @Html.HiddenFor(m => m.Skills[i].Id)
      ....
    }
