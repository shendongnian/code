    public class AnimalMap : JsonMap<Animal>
    {
        public AnimalMap()
        {
            this.DiscriminateSubClassesOnField("class");
            this.Map(x => x.Speed, "speed");
        }
    }
    
    public class FelineMap : JsonSubclassMap<Feline>
    {
        public FelineMap()
        {
            this.Map(x => x.SightRange, "sight");
        }
    }
    
    public class LionMap : JsonSubclassMap<Lion>
    {
        public LionMap()
        {
            this.DiscriminatorValue("lion");
            this.Map(x => x.Strength, "strength");
        }
    }
