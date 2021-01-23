    public class Employee{
      public string departmentName {get;set;}
      // Other properties
    }
    @Html.DropDownList(departmentName ,(SelectList)ViewBag.Departments,"Select Department",String.Empty)
 
