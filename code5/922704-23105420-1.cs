    @for (int i = 0; i < Model.propName.Count; i++)
    {
        @Html.CheckBoxFor(m => m.propName[i].Checked, new { id = "propName_" + i })
        @Html.TextBoxFor(m => m.propName[i].Name, new { id = "propName_" + i })
    }
