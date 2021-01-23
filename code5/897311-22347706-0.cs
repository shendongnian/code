    public abstract class GridObjectDataSource<T> : INotifyPropertyChanged
    {
        public abstract void DoSomething(T someInput);
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MySpecificViewModel : GridObjectDataSource<int>
    {
    
        public override void DoSomething(int someInput)
        {
    
        }
    }
