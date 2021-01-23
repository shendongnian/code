    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class ViewModel : BindableBase
    {
        object _Selected = default(object);
        public object Selected
        {
            get { return _Selected; }
            set
            {
                base.SetProperty(ref _Selected, value);
                if (value == null)
                    this.Button1Visibility = this.Button2Visibility = Visibility.Collapsed;
                else
                    this.Button1Visibility = this.Button2Visibility = Visibility.Visible;
            }
        }
        Visibility _Button1Visibility = default(Visibility);
        public Visibility Button1Visibility { get { return _Button1Visibility; } set { base.SetProperty(ref _Button1Visibility, value); } }
        Visibility _Button2Visibility = default(Visibility);
        public Visibility Button2Visibility { get { return _Button2Visibility; } set { base.SetProperty(ref _Button2Visibility, value); } }
    }
