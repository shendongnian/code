    public class ReportOutline
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }    
        public virtual ICollection<OutlineItem> OutlineItems { get; set; }
        public ICollection<OutlineItem> RootOutlineItems { 
            get {
                return OutlineItems.Where(p=> p.ParentOutlineItem == null);
            }
        }
    }
