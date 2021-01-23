    public partial class Languages
    {
       DataAnnotation  here
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public partial class Categories
    {
        public string Code { get; set; }
        public string FKLanguageCode { get; set; }
        public string Name { get; set; }
        public Nullable<int> Order { get; set; }
    
         DataAnnotation Not Here
        public virtual Languages Languages { get; set; }
     }
