    public class Page : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PageID { get; set; }
        [ForeignKey("Parent")]
        public int? Parent_PageID { get; set; }
        public int Order { get; set; }
        public bool Live { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string SEOKeywords { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public virtual Page Parent { get; set; }
        public virtual ICollection<Page> Children { get; set; }
        public IDictionary<int, string> PossibleParents
        {
            get
            {
                Dictionary<int, string> items = new Dictionary<int, string>();
                items.Add(-1, "Please Select");
                using (var context = new WebsiteContext())
                {
                    var pages = context.Pages;
                    foreach (var p in pages)
                        items.Add(p.PageID, p.Name);                    
                }
                return items;
            }
        }
        public Page()
        {
            this.Order = 0;
            this.Live = false; 
        }
    }
