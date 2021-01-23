    public class CustomControlA
    {
        public void OverrideableMethod()
        {
            // do something
        }
    }
    
    public class UserContorlB : System.Web.UI.UserControl
    {
        protected CustomControlA someVariableForCustomControlA;
    
        public void OverrideableMethod()
        {
            if(some condition is true)
            {
                 someVariableForCustomControlA.OverrideableMethod();
            }
            else 
            {
                 // do some logic here
            }   
        }
    }
