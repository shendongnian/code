    @for (int i = 0; i < Model.propName.Count; i++)
    {
        @Html.CheckBoxFor(m => m.propName[i].Checked, new { name = "propName_" + i })
        @Html.TextBoxFor(m => m.propName[i].Name, new { name = "propName_" + i })
    }
