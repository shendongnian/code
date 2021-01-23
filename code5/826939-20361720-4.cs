    public class PersonViewModel:INotifyPropertyChanged
    {
        private string _name;
        public string Name{ get{return _name;}
                            set{ SetProperty(ref _name, value);}}
        private string _tel;
        public string Tel{ get{return _tel;}
                            set{ SetProperty(ref _tel, value);}}
        public PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value, 
             [CallerMemberName] string name = ""){
             field = value;
             if(PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(name));
                 
        }
    }
