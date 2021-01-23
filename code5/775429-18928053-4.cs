    public class OrdenarEntidades<T>
    {
        public static IOrderedEnumerable<T> SortList(IEnumerable<T> Listado, params Func<T, object>[] orders)
        {
           if(orders.Length == 0)
               return Listado;
           IOrderedEnumerable<T> result = Listado.OrderBy(orders[0]);
           for(int i = 1; i < orders.Length; ++i)
               result = result.ThenBy(orders[i]);
           return result;
        }
    }
