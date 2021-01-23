    public class MyColorModel : BindableBase
    {
        Color _Color = default(Color);
        public Color Color { get { return _Color; } set { SetProperty(ref _Color, value); } }
        Visibility _Selected = Visibility.Collapsed;
        public Visibility Selected { get { return _Selected; } set { SetProperty(ref _Selected, value); } }
        public event EventHandler RemoveRequested;
        public void RemoveMe()
        {
            if (RemoveRequested != null)
                RemoveRequested(this, EventArgs.Empty);
        }
        public event EventHandler SelectRequested;
        public void SelectMe()
        {
            if (SelectRequested != null)
                SelectRequested(this, EventArgs.Empty);
        }
    }
    public class MyViewModel : BindableBase
    {
        public MyViewModel()
        {
            this.Selected = this.Colors[1];
            foreach (var item in this.Colors)
            {
                item.RemoveRequested += (s, e) =>
                {
                    this.ShowAnimations = false;
                    this.Colors.Remove(s as MyColorModel);
                    this.ShowAnimations = true;
                };
                item.SelectRequested += (s, e) => this.Selected = s as MyColorModel;
            }
        }
        ObservableCollection<MyColorModel> _Colors = new ObservableCollection<MyColorModel>(new[]
        {
          new MyColorModel{ Color=Windows.UI.Colors.Red }, 
          new MyColorModel{ Color=Windows.UI.Colors.Green }, 
          new MyColorModel{ Color=Windows.UI.Colors.Yellow }, 
          new MyColorModel{ Color=Windows.UI.Colors.Blue }, 
          new MyColorModel{ Color=Windows.UI.Colors.White }, 
          new MyColorModel{ Color=Windows.UI.Colors.Brown }, 
          new MyColorModel{ Color=Windows.UI.Colors.SteelBlue }, 
          new MyColorModel{ Color=Windows.UI.Colors.Goldenrod },
        });
        public ObservableCollection<MyColorModel> Colors { get { return _Colors; } }
        MyColorModel _Selected = default(MyColorModel);
        public MyColorModel Selected
        {
            get { return _Selected; }
            set
            {
                if (_Selected != null)
                    _Selected.Selected = Visibility.Collapsed;
                value.Selected = Visibility.Visible;
                SetProperty(ref _Selected, value);
            }
        }
        bool _ShowAnimations = true;
        public bool ShowAnimations { get { return _ShowAnimations; } set { SetProperty(ref _ShowAnimations, value); } }
    }
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
        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
