    public class WndViewModel : ViewModelBase // the base class implementing INotifyPropertyChanged
    {
        private ObservableCollection<Data> _db;
        public ObservableCollection<Data> Db 
        { 
            get { return _db ?? (_db = new ObservableCollection<Data>()); 
        }
        public WndViewModel()
        {
            Db.Add(new Data { Name = "person1", Description = "sssssss", Price = 15 });
            Db.Add(new Data { Name = "person2", Description = "okokok", Price = 12 });
        }
    }
