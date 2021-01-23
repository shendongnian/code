    public class PerRequestTransientLifetimeManager : ILifetimePolicy
    {
        public object GetValue()
        {
            // will always create a new object (Transient)
            return null;
        }
        public void SetValue(object newValue)
        {
            // No point in saving to http context if not disposable
            if (newValue is IDisposable)
            {
                var perRequestLifetimeManager = new PerRequestLifetimeManager();
                perRequestLifetimeManager.SetValue(newValue);
            }
        }
        public void RemoveValue()
        {
            // can't remove since transient didn't keep a reference
        }
    }
