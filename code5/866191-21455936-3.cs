    @model MVC.Controllers.User
    
    @{
        ViewBag.Title = "FirstStep";
    }
    
    <h2>FirstStep</h2>
    
    @using (Html.BeginForm("LastStep", "User", FormMethod.Post))
    {
        @Html.HiddenFor(model => model.Fname);
        @Html.HiddenFor(model => model.Lname);
    
        for (int i = 0; i < Model.Dates.Count; i++)
        {
            @Html.LabelFor(model => Model.Dates[i].date, new { @class = "control-label col-md-2" })
            @Html.EditorFor(model => Model.Dates[i].date)
            @Html.ValidationMessageFor(model => Model.Dates[i].date)
        }
        <input type="submit" value="Create" class="btn btn-default" />
    }
