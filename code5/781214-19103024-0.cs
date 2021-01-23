    public abstract class ReactiveObjectBase : ReactiveObject
    {
        [NotifyPropertyChangedInvocator]
        protected void RaiseAndSetIfPropertyChanged<T>(ref T obj, T value, string propertyName)
        {
            // call real raise method here
        }
    }
