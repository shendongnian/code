    public class BaseViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Selected")]
        [ExportItem(Exclude = true)]
        public bool Selected { get; set; }
    }
