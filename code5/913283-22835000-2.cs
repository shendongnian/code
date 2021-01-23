    @{
        var projectList = 
            new SelectList(ViewBag.ProjectList, "Value", "Text", Model.GetTimeSheetDetails[i].PROJ_ID.ToString())
    }
    @Html.DropDownListFor(m => m.GetTimeSheetDetails[i].PROJ_ID, projectList, "-- Choose a Project --")
