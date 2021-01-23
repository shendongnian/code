    public class Employee{
      public int selectedDepartmentId {get;set;}
      // Other properties
    }
    @Html.DropDownList("selectedDepartmentId",(SelectList)ViewBag.Departments,"Select Department",String.Empty)
 
