    public class ComponentBase : Component, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            var changeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (changeService != null)
                changeService.OnComponentChanged(this, TypeDescriptor.GetProperties(this).Find(propertyName, false), field, value);
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
