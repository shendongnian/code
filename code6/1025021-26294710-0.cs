        public abstract class ParentForm : IFormWithList
        {
            public abstract List<string> TheList { get; }
        }
    Where `IFormWithList` is:
        List<string> TheList { get; }
    Then you should declare it in each deriving class:
        public class f1 : ParentForm
        {
            public override List<string> TheList { get { return this.list; } }
        }
