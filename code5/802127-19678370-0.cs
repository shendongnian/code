    public abstract class BaseTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Table("DerivedWithRelation")]
    public class DerivedWithRelation : BaseTable
    {
        public int Amount { get; set; }
        public string About { get; set; }
        public int RelatedId { get; set; }
        public virtual ICollection<Relation> Relations { get; set; }
    }
    [Table("DerivedWithoutRelation")]
    public class DerivedWithoutRelation : BaseTable
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
    public class Relation
    {
        public int Id { get; set; }
        public string RelationshipType { get; set; }
        public virtual DerivedWithRelation DerivedWithRelation { get; set; }
    }
