        // Relationships
        this.HasRequired(t => t.LightHead)
            .WithOptional(t => t.Lens)
            .HasForeignKey(t => t.LightHeadId)
        this.HasRequired(t => t.LightHead1)
            .WithOptional(t => t.Lens1);
            .HasForeignKey(t => t.LightHead1Id)
 
...
    public class Lens
    {
        public int Id { get; set; }
        public int LightHeadId {get;set;}
        public int LightHead1Id {get;set;}
        public virtual LightHead LightHead { get; set; }
        public virtual LightHead LightHead1 { get; set; }
    }
    
    public class LightHead
    {
        public int Id { get; set; }
        public virtual Lens Lens { get; set; }
        public virtual Lens Lens1 { get; set; }
    }
