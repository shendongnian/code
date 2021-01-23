    public class MyInstanceProviderBehavior : IInstanceProvider
    {
    
      ...
    
      #region IInstanceProvider Members    
    
      public void ReleaseInstance(InstanceContext instanceContext, object instance)
      {
         ...
      }
    
      #endregion
    }
