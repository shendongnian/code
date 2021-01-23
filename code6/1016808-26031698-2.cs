    public interface ITestableAction{
        void Execute(string locator);
    }
    
    public class OriginInputAction : ITestableAction{
        public void Execute(string locator){
            origin_input(locator, "MEL");  //I'd make the origin_input method static...
        }
    }
    
    public class DestinationInputAction : ITestableAction{
        public void Execute(string locator){
            destination_input(locator, "Manila");    
        }
    }
