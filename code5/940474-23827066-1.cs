    public class PerRequestTransientLifetimeManager : ILifetimePolicy
    {
        public object GetValue()
        {
            // will always create a new object (Transient)
            return null;
        }
        public void SetValue(object newValue)
        {
            // Unity will now track and dispose this object when the request has ended.
            var perRequestLifetimeManager = new PerRequestLifetimeManager();
            perRequestLifetimeManager.SetValue(newValue);
        }
        public void RemoveValue()
        {
            // can't remove since transient didn't keep a reference
        }
    }
