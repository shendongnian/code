    ObservableCollection<ToDoItemModel> _myModel = new ObservableCollection<ToDoItemModel>();
    public ICommand AddToDo
    {
    get
      {
      return new RelayCommand(addToDo);
      }
    }
    public ToDoListModelView()
    {
     _myModel.Add(new ToDoItemModel() { ToDoDate = DateTime.Now, ToDoDescription = "Testing 1" });
     _myModel.Add(new ToDoItemModel() { ToDoDate = DateTime.Now.AddDays(1), ToDoDescription = "Testing 2" });
    }
    public ObservableCollection <ToDoItemModel> myModel 
    { 
     get { return _myModel; } 
    }
