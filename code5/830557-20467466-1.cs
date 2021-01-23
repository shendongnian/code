    class Program
    {
        static void Main( string[] args )
        {
            Animal animal = new Animal() { AnimalId = 1, Name = "Man1" };
            Man man = new Man();
            man.InjectFrom<Animal>( animal );
        }
    }
    public class Animal:ConventionInjection
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        protected override bool Match( ConventionInfo c )
        {
            return ((c.SourceProp.Name == "AnimalId") && (c.TargetProp.Name == "AnimalId"));
        }
    }
    public class Man : Animal
    {
       
        //Primary key as well as foreign key will be AnimalId. 
        public string Communicate { get; set; }
    }
