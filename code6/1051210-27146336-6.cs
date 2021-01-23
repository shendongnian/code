    public class ActorMap : ClassMap<Actor>
    {
        public ActorMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasMany(x => x.MovieAssociations)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("ActorId")
                .Not.KeyNullable();
        }
    }
    public class MovieActorAssociationMap : ClassMap<MovieActorAssociation>
    {
        public MovieActorAssociationMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.SomeOtherProperty);
            References(x => x.Movie)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("MovieId")
                .UniqueKey("Movie_Actor");
            References(x => x.Actor)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("ActorId")
                .UniqueKey("Movie_Actor");
        }
    }
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasMany(x => x.ActorAssociations)
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .KeyColumn("MovieId")
                .Not.KeyNullable();
        }
    }
