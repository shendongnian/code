    public class BaseClass {
        public virtual bool DoesSomething {
            get {
                return true;
            }
        }
        public void Print() {
            Console.WriteLine(DoesSomething);
        }
    }
    public class ChildClass : BaseClass {
        public override bool DoesSomething {
            get {
                return false;
            }
        }
    }
