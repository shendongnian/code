    public interface IItem { }
    public class AuctionItem : IItem { }
    public class BuyNowItem : IItem { }
    public interface IResult<out T> where T : IItem {
      IList<IItem> Items { get; set; }
      int TotalCount { get; set; }
    }
    public class SearchResult<T> : IResult<T> where T : IItem
    {
      public IList<IItem> Items { get; set; }
      public int TotalCount { get; set; }
    }
