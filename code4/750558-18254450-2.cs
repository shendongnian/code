    public class Disposer
    {
       private List<IDisposable> disposables = new List<IDisposable>();
    
       public void Register(IDisposable item)
       {
          disposables.Add(item);
       }
       public void Unregister(IDisposable item)
       {
          disposables.Remove(item);
       }
       public void DisposeAll()
       {
          foreach (IDisposable item in disposables)
          {
            item.Dispose();
          }
          disposables.Clear();
       }
    }
