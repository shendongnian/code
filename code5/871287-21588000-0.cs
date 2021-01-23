    public abstract class NotifyPropertyChanged : ISupportInitialize {
       ...
       public void BeginInit() { }
       public void EndInit() { PropertyChangedObserver() }
    }
