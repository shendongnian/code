    public class EntityMap : ClassMap<Entity>
    {
        Id(e => e.Id).GeneratedBy.Identity();
        Map(Reveal.Member<Entity>("PrivatePropertyName"));
    }
