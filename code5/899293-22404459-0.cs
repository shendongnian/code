    public class CompleteParameters
    {
      string parm1;
      // whatever you want
    };
    
    public class CompleteParametersTwo : CompleteParameters
    {
      string parm2;
    };
    
    
    public interface ICompleteable 
    {
        public void Complete(CompleteParameters parms);
    }
