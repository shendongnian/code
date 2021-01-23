    public class AccountInfo {
        ... // stuff you already have
        public virtual AccountInfo Parent { get; set; }
    }
    
    // in the configuration (this is using Code-first configuration)
    conf.HasOptional(a => a.Parent).WithMany(p => p.Children).HasForeignKey(a => a.ParentKey);
