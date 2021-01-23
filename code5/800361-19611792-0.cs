     public abstract class AbstractListDataType { 
         public void Load(RawData data)....
     }
     public class ListGenerator<TListDataType> 
         where TListDataType : AbstractListDataType, new()
         public List<TListDataType> GenerateList()
         {
            RawDataType data = new RawDataType() { ... }
            var item = new T();
            item.Load(data);
            return new List<TListDataType>() { item };
         }
     }
   
