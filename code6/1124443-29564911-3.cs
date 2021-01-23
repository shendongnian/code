      [Designer(typeof(ActivityDesigner1))]
      public sealed class CodeActivity1 : CodeActivity
    {
        public CodeActivity1()
        {
              Activities = new List<Activity>();
            Activities.Add(new Assign());
            Activities.Add(new Assign());
        }
       public List<Activity> Activities { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
        }
    }
