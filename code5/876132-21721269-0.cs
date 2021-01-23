    public class ThreadableObservableCollection<T> : ObservableCollection<T>
    {
        private readonly Dispatcher _dispatcher;
        public ThreadableObservableCollection()
        {
          _dispatcher = Dispatcher.CurrentDispatcher;
        }
    
        public void ThreadsafeRemove(T item, Action callback)
        {
          if (_dispatcher.CheckAccess())
          {
            Remove(item);
            callback();
          }
          else
          {
            _dispatcher.Invoke(() =>
              {
                Remove(item);
                callback();
              });
          }
        }
    
        public void ThreadsafeInsert(int pos, T item, Action callback)
        {
          if (_dispatcher.CheckAccess())
          {
            Insert(pos, item);
            callback();
          }
          else
          {
            _dispatcher.Invoke(() =>
              {
                Insert(pos, item);
                callback();
              });
          }
        }
      }
