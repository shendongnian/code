    public class Permission
    {
        public int PermissionId { get; set; }
        [Required, StringLength(150)]
        public string Title { get; set; }
        public virtual List<PermissionDependency> Dependencies { get; set; }
    }
    public class PermissionDependency
    {
        public int PermissionDependencyId { get; set; }
        [DefaultValue(true)]
        public bool IsRequired { get; set; }
    } 
