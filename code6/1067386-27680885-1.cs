    public class Article
    {
        [Key]
        public Guid ID { get; set; }
        public string Tags { get; set; } 
        public string Name { get; set; }
        public string Link { get; set; }
        public string HtmlContent { get; set; }
        [ForeignKey("ListaId")]
        public Lista Lista { get; set; }
        public Guid ListaId { get; set; }
    
        public Article(){
           ID = Guid.NewGuid();
        }
    
    }
