    public class SomeViewModel : INotifyPropertyChanged
    {
        private bool isCheckBoxOneChecked;
        public bool IsCheckBoxOneChecked
        {
            get { return isCheckBoxOneChecked; }
            set
            {
                if (value.Equals(isCheckBoxOneChecked))
                {
                    return;
                }
                isCheckBoxOneChecked = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
----------
    <CheckBox IsChecked="{Binding IsCheckBoxOneChecked}" Content="Boo" Grid.Column="0" Grid.Row="0"/>
    <CheckBox Content="Hoo" Grid.Column="0" Grid.Row="1"/>
