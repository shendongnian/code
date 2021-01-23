    public class Employee{
      public string DepartmentName {get;set;}
      // Other properties
    }
    @Html.DropDownList(DepartmentName ,(SelectList)ViewBag.Departments,"Select Department",String.Empty)
