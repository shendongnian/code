    public class EditFooVm {
      public int FooId { get; set; }
      [Required(ErrorMessage = "Please select a foo")]
      public int FooDropDownId { get; set; }
      public SelectList FooDropDown { get; set; }
    }
