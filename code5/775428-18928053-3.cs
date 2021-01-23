    public class OrdenarEntidades<T>
    {
        public static IEnumerable<T> SortList(IEnumerable<T> Listado, params Func<T, object>[] orders)
        {
           var result = IEnumerable<T> Listado;
           if(orders.Length > 0)
               result = result.OrderBy(orders[0]);
           for(int i = 1; i < orders.Length; ++i)
               result = result.ThenBy(orders[i]);
           return result;
        }
    }
