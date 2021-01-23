    using MicroMvvm;
    
    namespace MyApplication
    {
        [Bindable]
        public partial class MyApplication
        {
            [Bindable] 
            private string _ipAdress;
    
            [Bindable] 
            private MyChild _child;
    
            public MyApplication()
            {
                IpAdress = "ip adress test";
                Child = new MyChild(this, "");
            }
    
            [Bindable]
            void AddDot()
            {
                IpAdress += ".";
            }
    
            [Can]
            bool CanChangeChild()
            {
                return IpAdress.Trim().Length != 0;
            }
    
            [Bindable]
            void ChangeChild()
            {
                Child = new MyChild2(this);
            }
        }
    }
