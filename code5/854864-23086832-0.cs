    public class ToDoDataViewModel  : INotifyPropertyChanged
    {
        ToDoDataContext  db;
        public ToDoDataViewModel(string connectionString)
        {
            db = new ToDoDataContext(connectionString);
        }
        private ObservableCollection<ToDoItem> _toDoItems;
        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return this._toDoItems; }
            set
            {
                this._toDoItems = value;
                NotifyPropertyChanged("ToDoItems");
            }
        }
        public void LoadCollectionsFromDatabase()
        {
            var toDos = from todo in db.ToDoItems
                          select todo;
            _toDoItems = new ObservableCollection<ToDoItem>(toDos);
            
        }
		
		public void InsertToDoItem(ToDoItem item)
		{
			db.ToDoItems.InsertOnSubmit(item);
			_toDoItems.Add(item);
			db.SubmitChanges();
		}
		
		public void DeleteToDoItem(ToDoItem item)
		{
			db.ToDoItems.DeleteOnSubmit(item);
			_toDoItems.Remove(item);
			db.SubmitChanges();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
