    @model HawkTimeModel.Employee
    @{
        ViewBag.Title = "Edit Employee";
    }
    <h2>Edit</h2>
    @{ Html.RenderPartial(MVC.Employees.Views._EmployeeForm); }
    <p>
        @Html.ActionLink("Back to List", MVC.Employees.Actions.Index())
    </p>
