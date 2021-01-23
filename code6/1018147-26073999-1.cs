    public class ParentA
    {
        Child B, C, D, E, F, G;
    
        public void Setup()
        {
            // pass CommonMethod or even just CallDelegate to the child classes
            B.SetParentMethod(this.CommonMethod);
            C.SetParentMethod(this.CommonMethod);
            D.SetParentMethod(this.CommonMethod);
            E.SetParentMethod(this.CommonMethod);
            F.SetParentMethod(this.CommonMethod);
            G.SetParentMethod(this.CommonMethod);
        }
    
        private void CommonMethod()
        {
            //Common task
            CallDelegate();
        }
    }
    
    public class Child
    {
        private Action parentMethod;
    
        public void SetParentMethod(Action parentMethod)
        {
            this.parentMethod = parentMethod;
        }
    
        public void DoSomeAction()
        {
            // call the common task
            this.parentMethod();
        }
    }
