    public class TaskViewModel
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public int State { get; set; }
      public string Description { get; set; }
      public string Notes { get; set; }
    }
    public class NRIAndCategoriesViewModel
    {
      public List<TaskViewModel> Tasks { get; set; }
      public SelectList StateList { get; set; }
      // other properties of the model to display in the main view
    }
