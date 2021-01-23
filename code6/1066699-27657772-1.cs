    //declare common functionality
    public interface ISharedFunctionality 
    {
        //put all shared functionality here
        void SomeMethod();
        void SomeOtherMethod();
        string Name {get;set;}
    }
    
    public interface ISinglePlayerFunctionality : ISharedFunctionality
    {
        //put single player functionality here
        void SomeOtherMethod();
        void SomeMethod();
    }
    
    public interface IMultiplePlayerFunctionality : ISharedFunctionality
    {
        //put multiplayer functionality here
        void DifferentMethod();
        void SomeMethod();
    }
    
    public class ImplementationBase : ISharedFunctionality
    {
        //shared implementation here
        public void SomeMethod()
        {
            //do stuff
        }
        public abstract SomeOtherMethod()
        {
            //one you don't want to inherit in single player
        }
    }
    public class MultiPlayerImplementation : ImplementationBase , IMultiplayerFunctionality
    {
        //multiplay impl
        // you inherit some method but don't want to inherit 
        //SomeOtherMethod when cast to ISharedFunctionality
        ISharedFunctionality.SomeMethod()
        {
            //when cast to ISharedFunctionality this method will execute not inherited
        } 
    }
    public class SinglePlayerImplementation : ImplementationBase , ISinglePlayerFunctionality
    {
        //singleplay impl
    }
    public class Facotry 
    {
        //logic to decide impl here
        ISharedContract Create(int numberOfPlayer)
        {
            //decide which one to make and return it here
        }
    }
