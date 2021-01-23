    [Serializable] 
    public class KeyMemberAttribute : LocationInterceptionAspect 
    { 
    
        public override void OnSetValue(LocationInterceptionArgs args) 
        {   
          args.ProceedSetValue();
          ((EntityBase)args.Instance).Key=null;
        }
    }
    
