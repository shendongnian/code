    public class Something<T>
    {
        public void ListToArray(List<Object> list)
        {
           var instances = list.Cast<T>().ToArray();
        }
    }
