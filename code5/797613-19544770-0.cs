    public abstract class EntityTypeTransform<TEntityType> where TEntityType : class
    {
      public abstract Func<IDataRecord, TEntityType> GetDataTransform();
    }
    public class TaskParameterEntityTypeTransform : EntityTypeTransform<TaskParameter>
    {
      public override Func<IDataRecord, TaskParameter> GetDataTransform()
      {
        return x => new TaskParameter { X = x.FieldCount };
      }
    }
    public class TaskParameter
    {
      public int X { get; set; }
    }
    Dictionary<Type, EntityTypeTransform<TaskParameter>> imADict;
