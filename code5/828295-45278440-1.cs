    public class RealClass{
        int DoSomething(string input)
        {
            // real implementation here
        }
    }
    
    public interface IRealClassAdapter{
        int DoSomething(string input);
    }
    
    public class RealClassAdapter : IRealClassAdapter{
        private readonly RealClass _realClass;
    
        public RealClassAdapter(){
            _realClass = new RealClass();
        }
    
        int DoSomething(string input){
            _realClass.DoSomething(input);
        }
    }
