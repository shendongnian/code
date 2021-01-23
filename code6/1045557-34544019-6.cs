    public class ConsignorUser
    {
        public int ConsignorId { get; set; }
        public string UserId { get; set; }
        public virtual Consignor Consignor { get; set; }
        public virtual User User { get; set; }
        
    }
    public static partial class Entity_FluentMappings
    {
        public static EntityTypeBuilder<ConsignorUser> AddFluentMapping<TEntity> (
            this EntityTypeBuilder<ConsignorUser> entityTypeBuilder) 
            where TEntity : ConsignorUser
        {
           entityTypeBuilder.HasKey(x => new { x.ConsignorId, x.UserId });
           return entityTypeBuilder;
        }      
    }
