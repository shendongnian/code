    public abstract class Model<T> : IDataErrorInfo
      {
        public ObservableCollection<T> Items;
    
        public virtual string Error
        {
          get { throw new NotImplementedException(); }
        }
    
        public virtual string this[string columnName]
        {
          get { throw new NotImplementedException(); }
        }
      }
