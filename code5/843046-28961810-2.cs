    public class Model
    {
        [Display(Name = "Some Name for A")]
        public int PropA { get; set; }
        [Display(Name = "Some Name for B")]
        public string PropB { get; set; }
    }
    public class ModelCollection
    {
        public List<Model> Models { get; set; }
        public Model Default
        {
            get { return new Model(); }
        }
    }
