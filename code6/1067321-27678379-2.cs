    @model WebApplication1.Controllers.CheckBoxViewModel
    
    @{
        ViewBag.Title = "AddQuestion";
    }
    
    <h2>AddQuestion</h2>
    
    @using (Html.BeginForm("EditCheckBox", "Home"))
    {
        for (int i = 0; i < Model.CheckBoxLists.Count; i++)
        {
            @Html.CheckBox(
                String.Format("CheckBoxLists[{0}].CheckBoxState", i.ToString()),
                Model.CheckBoxLists[i].CheckBoxState,
                new { id = Model.CheckBoxLists[i].CheckBoxId })
            @Html.Label(Model.CheckBoxLists[i].CheckBoxDescription)
    
            @Html.Hidden(String.Format("CheckBoxLists[{0}].CheckBoxDescription", i.ToString()), Model.CheckBoxLists[i].CheckBoxDescription)
            @Html.Hidden(String.Format("CheckBoxLists[{0}].CheckBoxId", i.ToString()), Model.CheckBoxLists[i].CheckBoxId)
        }
    
        <input type="submit" value="Click" />
    }
