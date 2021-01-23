    interface IMyInterface
    {
        void Call();
    }
    
    //Requirement: I have to call the randomNumber Method from the main class.
    public class ClassBasedOnInterface : IMyInterface
    {
        SeperateClass hasASeperateClass = new SeperateClass();
        public void Call()
        {
            //Could be local variable.  
            //Or, the professor could be implying that ClassBasedOnInterface has a SeperateClass 
            //member that is used to make the call to GetRandomNumber().  
            //Or, GetRandomNumber() could be static.
            //var seperateClass = new SeperateClass();//I do not consider a private local variable a HAS-A relationship
            //seperateClass.GetRandomNumber();
            hasASeperateClass.GetRandomNumber();
        }
    }
    public class SeperateClass
    {
        public void GetRandomNumber()
        {
            
        }
    }
