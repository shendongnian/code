    @using WebReporter.Models
    
    @{ Html.RenderPartial(MVC.Employees.Views._IndexPartial); }
    
    @if (Model.HomePage == HomePage.Timesheets)
    {
        <p>
            @Html.ActionLink("Back to Timesheet Overview", MVC.TimeSheets.Index())
        </p>
    }
