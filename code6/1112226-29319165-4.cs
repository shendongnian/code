    public class BaseCtrl : UserControl
    {   
        protected ChildControl DerivedCC
        {
            get { return (ChildControl)this.FindControl("CC"); }
        }
    }
