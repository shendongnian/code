    @for (int i = 0; i < Model.Skills.Count; i++)
    {
        @Html.CheckBoxFor(m => m.Skills[i].Selected , new { id = "sikll_" + i })
        @Html.HiddenFor(m => m.Skills[i].Id)
        @Html.HiddenFor(m => m.Skills[i].Name)
        @Html.DisplayFor(m => m.Skills[i].Name)
    }
