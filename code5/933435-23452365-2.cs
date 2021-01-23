    public class PagingInfo
    {
         public int ItemsPerPage { get; set; }
         public int NumItems { get; set; }
         public int CurrentPage { get; set; }
         public int TotalPages
         {
             get
             {
                 return Math.Ceiling((double)NumItems/ItemsPerPage);
             }
         }
    }
