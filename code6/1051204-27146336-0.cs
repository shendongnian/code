    public class ActorMap : ClassMap<Actor>
    {
        public ActorMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Movies)
                .Table("Actors_Movies")
                .ParentKeyColumn("ActorId")
                .ChildKeyColumn("MovieId")
                .LazyLoad()
                .Cascade.AllDeleteOrphan();
        }
    }
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Actors)
                .Table("Actors_Movies")
                .ParentKeyColumn("ActorId")
                .ChildKeyColumn("MovieId")
                .Inverse();
        }
    }
