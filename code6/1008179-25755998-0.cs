        public void Init()
        {
            PropertyChanged += Delegate1;
            // other stuff 
        } 
        Void Delegate1 .... 
    }
 
    public class SecondClass : Bindable
    {
        
        private FirstClass _MyFirstClass
        public FirstClass MyFirstClass
        {
            get { return _MyFirstClass; }
            set { SetProperty(ref _MyFirstClass, value); }
        } 
        public SecondClass()
        {
            MyFirstClass = new FirstClass();     
            MyFirstClass.PropertyChanged += Delegate2;
            MyFirstClass.Init();
        } 
        Void Delegate2 .... 
    }&#xD;
