    public class MegaList<T> : ObservableCollection<T>
    {
       public ObservableCollection<TBase> UpCast<TBase, T>()  // <-- this T isn't outer T
          where TBase : class
          where T : TBase
       {
          var listUpcast = new ObservableCollection<TBase>();
          foreach (T t in this.Items)  // <-- error: Argument type 'T' is not assignable to parameter type 'TBase'
            listUpcast.Add(t);
          return listUpcast;
       }
    }
