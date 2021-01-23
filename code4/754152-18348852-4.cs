    public class MyComparer<T> : IComparer<T> {
       public MyComparer(SortingDirection sortDir){
          Direction = sortDir;
       }
       public SortingDirection Direction {get;set;}
       public int Compare(T x, T y){
          //your normal logic
          int result = ....;
          return Direction == SortingDirection.Descending ? -result : result;
       }
       public enum SortingDirection {
         Ascending,
         Descending
       }
    }
    //o.SortingDirection should be type of enum SortingDirection
    source.OrderBy(o=>o.MyColumnToOrderBy, new MyComparer(o.SortingDirection));
