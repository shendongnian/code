    @for(var i = 0; i < Model.CheckBoxList.Count; i++)
    {
         <label class="checkbox">
            @Html.HiddenFor(m => Model.CheckBoxList[i].ID)
            @Html.HiddenFor(m => Model.CheckBoxList[i].Name)
            @Html.CheckBoxFor(m => Model.CheckBoxList[i].Checked)
            @Model[i].Name
        </label>
    
    }
