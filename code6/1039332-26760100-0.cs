        public partial class MyEntity : INotifyPropertyChanged
        {
            // Methods
        }
        public class MyViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<MyEntity> _listEntities = new ObservableCollection<MyEntity>();
            public ObservableCollection<MyEntity> ListEntities
            {
                get { return this._listEntities; }
                set { /* code here... */}
            }
        }
