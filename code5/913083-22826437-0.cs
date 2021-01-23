    public class WebApiEntity
    {
        public string id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public Collection<CData> data { get; set; }
    }
