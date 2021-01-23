     public interface IDisplayItem
     {
         dynamic Item { get; }
         Func<string> DisplayValueFn { get; }
     }
    
     public class DisplayItem<T> : IDisplayItem
     {
         public T Item { get; set; }
    
         dynamic IDisplayItem.Item
         {
             get { return Item; }
         }
    
         public Func<T, string> DisplayValueFn { get; set; }
    
         Func<string> IDisplayItem.DisplayValueFn
         {
             get { return () => DisplayValueFn(Item); }
         }
     }
