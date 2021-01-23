    public class MegaList<T> : ObservableCollection<T>
    {
        // ...rest of class snipped...
        public ObservableCollection<TBase> UpCast<TBase>()
        {
            var listUpcast = new ObservableCollection<TBase>();
            foreach (var t in this.Items)
                listUpcast.Add((TBase)t); // <-- error: Argument type 'T' is not assignable to parameter type 'TBase'
            return listUpcast;
        }
    }
