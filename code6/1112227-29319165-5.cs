    public class BaseCtrl : UserControl
    {   
        protected ChildControl CC;
        protected ChildControl DerivedCC
        {
            get { return this.CC; }
        }
    }
