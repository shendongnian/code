    [Attributes...]
    public class MyTableEntity : ITableEntity {
      private TableEntity decoratedTableEntity;
      public void ReadEntity(args...) {
        decoratedTableEntity.ReadEntity(args...);
      }
    
    }
