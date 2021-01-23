    public class Page {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual Page Parent { get; set; }
        public virtual IList<Page> Children { get; set; }
    }
    public class PageClassMap : ClassMap<Page> {
        public PageClassMap() {
            Table("Page");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title);
            Map(x => x.Body);
            References(x => x.Parent);
            HasMany(x => x.Children).KeyColumn("ParentId");
        }
    }
