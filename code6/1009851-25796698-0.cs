    public class DatabaseViewModel
    {
        public DatabaseViewModel()
        {
            TempView = new DatabaseByTempViewModel();
            ProductView = new DatabaseByProductViewModel();
        }
        
        public DatabaseByTempViewModel TempView { get; set; }
        public DatabaseByProductViewModel ProductView{ get; set; }
    }
