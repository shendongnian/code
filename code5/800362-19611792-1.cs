     public abstract class ListItemFactory<T> 
     {
          abstract public T CreateFromRawData(RawDataType data);
     }
     public class ListGenerator<TListDataType> 
         where TListDataType : AbstractListDataType
     {
         ListItemFactory<TListDataType> factory;
         public ListGenerator<TListDataType>(ListItemFactory<TListDataType> factory)
         {
             this.factory = factory;
         }
         public List<TListDataType> GenerateList()
         {
            RawDataType data = new RawDataType() { ... }
            return new List<TListDataType>() { factory.CreateFromRawData(data)};
         }
     }
