    public class ViewModel1
    {
        public ViewModel2 ViewModel2 {get;set;}
    
        void SomeMethod()
        {
            ViewModel2.SomeProperty = "SomeValue";     
            ViewModel2.ExecuteSomeAction(someParameter);
        }
    }
