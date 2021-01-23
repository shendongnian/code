    interface IFoo 
    {
        void SomeMethod (int para = DefaultPara);
    }
    
    public class SubFoo : IFoo {
    
        public void SomeMethod (int para = DefaultPara) {
            //do something
        }
    
    }
