    @model MVC.Controllers.ReportsModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    @using (Html.BeginForm("Submit", "Checkbox", FormMethod.Post))
    {
        for (int i = 0; i < Model.ReportsList.Count; i++)
        {
            @Html.CheckBoxFor(m => m.ReportsList[i].IsChecked) @Model.ReportsList[i].Report.ReportName
            <br />
        }
        <input type="submit" value="Click" />
    }
