    public interface IBaseForm
    {
        void SomeMethod1();
        void SomeMethod2(bool someParameter);
        string SomeProperty { get; set; } 
    }
    public class DetailerReport: Form, IBaseForm
    {
        Math _math;
        public DetailerReport()
        {
            InitializeComponents();
            _math = new Math(this);
        }
        // impolement IBaseForm
        public void SomeMethod1() { ... }
        ...
    }
    public class Math
    {
        IBaseForm _form;
        public Math(IBaseForm form)
        {
            _form = form;
            // and then you can use call methods
            _form.SomeMethod1();
        }   
    }
