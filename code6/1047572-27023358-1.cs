        public class BaseClass
        {
            public virtual string GetName()
            {
                return string.Empty;
            }
        }
        public partial class ChildClass : BaseClass
        {
            public string FullName;
            public int Marks;
            public override string GetName()
            {
                return FullName;
            }
        }
