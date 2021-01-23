    public class EntityType1Map : ClassMap<EntityType1>
    {
        public EntityType1Map()
        {
            Id(m => m.Id);
            Map(m => m.EntityTypeName1);
            HasMany(m => m.Notes)
              // this "table" setting is redundant, it will come from EntityType1ToNote
              //.Table("EntityToNotes")
              .KeyColumn("EntityId")
              // here is the trick, that only related rows will be selected
              .Where("Discriminator = 'EntityType1'")
              .Cascade.AllDeleteOrphan();
        }
    }
