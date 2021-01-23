    public interface IParameterizedClass
    {
       string ClassParameter {get}
    }
        
    public class class1 : IParameterizedClass
    {
       public string ClassParameter {get; private set;}
       public class1(string someParameter)
       {
         // do some work
    
         ClassParameter = someParameter;
       }
    }  
    
    public class class2 : IParameterizedClass
    {
       public string ClassParameter {get; private set;}
       public class2(string someParameter)
       {
         // do some work
    
         ClassParameter = someParameter;
       }
    }
    
    public void getConstructorParametersToList()
    {
        string[] myArrayList = null;
        for(int i = 0; i < classList.Count; i++)
        {
            //Add the parameters from the constructors to a string array
            myArrayList[i] = (classList[i] as IParameterizedClass).ClassParameter;
        }
    }
