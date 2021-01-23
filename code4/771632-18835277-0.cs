    public class PageMap : ClassMapping<Page>
    {
        public PageMap()
        {
           ..
           ManyToOne(x => x.ParentCategory, m =>
                {
                    m.Cascade(Cascade.All);
                    m.NotNullable(true);
                });
        }
    }
