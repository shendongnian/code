    @Html.DropDownList("DepartmentId", (SelectList)ViewBag.Departments,"Select Department")
    public class Employee
        {
            ...
            public string DepartmentId { get; set; } // now binding
            public Department Department { get; set; }
        }
