    public class ViewModel
    {
    
        public Dictionary<int, string> LisOfFields { get; set; }
        public int[] SelectedFields { get; set; }
    
    
        public ViewModel()
        {
            LisOfFields = new Dictionary<int, string>()
            {
            {1, "Field1"},
            {2, "Field2"},
            {3, "Field3"},
            };
    
        }
    }
