    public class ConsignorUserMapping
    {
        public int ConsignorId { get; set; }
        public string UserId { get; set; }
        public virtual Consignor Consignor { get; set; }
        public virtual User User { get; set; }
        
    }
    public static class Entity_FluentMappings
    {
        public static EntityTypeBuilder<TEntity> AddFluentMapping<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder) where TEntity : ConsignorUserMapping
        {
           entityTypeBuilder.HasKey(x => new { x.ConsignorId, x.UserId });
           return entityTypeBuilder;
        }      
    }
