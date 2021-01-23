    public class MyModel
    {
      [Required(ErrorMessage = "Please select an organisation")]
      [Display(Name = "Organisation")]
      public int? SelectedOrganisation { get; set; }
      [Required(ErrorMessage = "Please select an employee")]
      [Display(Name = "Employee")]
      public int? SelectedEmployee { get; set; }
      public SelectList OrganisationList { get; set; }
      public SelectList EmployeeList { get; set; }
    }
