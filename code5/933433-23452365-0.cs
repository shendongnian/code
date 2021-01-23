    public class PagingInfo
    {
         public int ItensPerPage { get; set; }
         public int NumItens { get; set; }
         public int CurrentPage { get; set; }
         public int TotalPages
         {
             get
             {
                 return Math.Ceiling((double)NumItens/ItensPerPage);
             }
         }
    }
