    public class YouModel{
	
	  [Display(Name = "Month")]
	  [Required(ErrorMessage = "This field is required")]
	  public String SelectedMonth {get; set;}
	  public List<SelectListItem> Months {get; set;}
	  [Display(Name = "Employee Name")]
	  [Required(ErrorMessage = "This field is required")]
	  public int SelectedEmployee {get; set;}
	  public List<SelectListItem> EmployeeList {get; set;}
    }
