    public class OrdenarEntidades<T>
    {
        public static IEnumerable<T> SortList(IEnumerable<T> Listado, params Func<T, object>[] orders)
        {
           var result = IEnumerable<T> Listado;
           foreach(var o in orders)
           {
               result = result.OrderBy(o);
           }
           return result;
        }
    }
