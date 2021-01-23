    List<ValidationResult> validationResults = new ...;
    Inspector inspector = commonInspector;
    bool additionalOp = commonFlag;
    HashSet<IThing> thingsToCheck = theThings;
    foreach (IThing thing in thingsToCheck)
    {
        thing.Validate(inspector);
    }
...
    public interface IThing
    {
        void Validate(Inspector inspector, ...);
    }
    public abstract CandyBase : IThing
    {
        public abstract void Validate(Inspector inspector);
    }
    public HardWrappedCandy : CandyBase
    {
        public override void Validate(Inspector inspector)
        {
             // HardWrappedCandy validation logic here
             var inspected = inspector.Inspect(this);
             ...
        }
    }
    public Chocolate : IThing
    {
        public void Validate(Inspector inspector)
        {
            // Chocolate validation logic here...
        }
    }
    public SomethingElseInTheFuture: IThing
    {
        public void Validate(Inspector inspector)
        {
            // SomethingElseInTheFuture validation logic here...
        }
    }
