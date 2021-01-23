    public void SetAndPersistObj(SomeObject value) {
        if (value != obj)
        {
            Task.Factory.StartNew(() =>
            {
               UpdateToSql(value); //if object exists updates it other wise inserts it
            });
            obj = value;
            OnPropertyChanged("Obj");
        }
    }
