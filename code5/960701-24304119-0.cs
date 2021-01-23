    public class DummyAttribute : ValidationAttribute, IClientValidatable
    {
        public DummyAttribute() : base("{0} contains invalid data.")
        ....
    }
