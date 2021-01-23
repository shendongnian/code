    public class Company
         {
        public virtual int CompanyId { get; set; }
        public virtual Company Parent{ get; set; }
        public virtual IList<Company>Children{get;set}
        }
                
    References(x => x.Parent, "ParentId").Nullable();
                HasMany(x => x.Children).Cascade.SaveUpdate().KeyColumn("ParentId");
