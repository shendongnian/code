    //declare common functionality
    public interface ISharedContract 
    {
        //put all shared functionality here
    }
    
    public interface ISinglePlayerFunctionality : ISharedFunctionality
    {
        //put single player functionality here
    }
    
    public interface IMultiplePlayerFunctionality : ISharedFunctionality
    {
        //put multiplayer functionality here
    }
    
    public class ImplementationBase : ISharedFunctionality
    {
        //shared implementation here
    }
    public class MultiPlayerImplementation : ImplementationBase , IMultiplayerFunctionality
    {
        //multiplay impl
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
