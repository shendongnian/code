    public class ViewModel
    {
        public string ImagePath{ get; set; }
    .....
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    
    
    }
