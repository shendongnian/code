    public interface IControlBehavior {
         void Activate(int input);
    }
    
    public class FirstPhase : IControlBehavior {
        void Activate(int input) {
           //call function1 with 1, function 2 with 2...
        }
    }
    
    public class SecondPhase : IControlBehavior {
        void Activate(int input) {
          //call function1 with 1, function 5 with 2...
        }
    }
