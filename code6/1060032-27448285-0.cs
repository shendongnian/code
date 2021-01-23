    public abstract class Animal
    {
        public abstract string Name { get; set; }
    }
    public class Cow : Animal
    {
        [Display(Name="Cow Name")]
        public override string Name { get; set; }
    }
    public class Pig : Animal
    {
        [Display(Name = "Pig Name")]
        public override string Name { get; set; }
    }
    public class Farm
    {
        public Cow Cow { get; set; }
        public Pig Pig { get; set; }
    }
