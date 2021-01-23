    public abstract class BaseCtrl : UserControl
    {
        protected abstract ChildControl DerivedCC { get; }
    }
    public class Derived1 : BaseCtrl
    {
        protected override ChildControl DerivedCC
        {
            get { return this.CC; }
        }
    }
    // And similarly for Derived2.
