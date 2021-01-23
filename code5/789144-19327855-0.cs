    public class HierarchicalEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public virtual HierarchicalEntity Parent { get; set; }
        public virtual ICollection<HierarchicalEntity> Children { get; set; }
    }
            using (var db = new TestEntities())
            {
                var parent = new HierarchicalEntity();
                db.HierarchicalEntity.Add(parent);
                var children = new List<HierarchicalEntity>()
                {
                    new HierarchicalEntity() { Parent = parent },
                    new HierarchicalEntity() { Parent = parent }
                };
                children.ForEach(c => db.HierarchicalEntity.Add(c));
                db.SaveChanges();
            }
