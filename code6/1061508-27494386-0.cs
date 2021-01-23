    public class ViewModel
    {
      public IEnumerable<ABC> Items { get; set; } 
      public string NameFilter { get; set; }
      public string DeviceFilter { get; set; }
      public string TypeFilter { get; set; }
      public SelectList DeviceList { get; set; }
      public SelectList TypeList { get; set; }
    }
