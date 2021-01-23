    public class Status
    {
        public string IconName{get;set;}
        public Canvas Icon 
        {
            get 
            {
                try
                {
                    return Application.Current.FindResource(IconName) as Canvas;
 
                }                
                catch(System.Windows.ResourceReferenceKeyNotFoundException e)
                {
                    return null;
                }
            }
        }
    }
