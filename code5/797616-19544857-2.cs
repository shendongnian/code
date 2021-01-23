    public interface IEntityTypeTransform<out TEntityType> where TEntityType : class
    {
        TEntityType Transform(IDataRecord dataRecord);
    }
    public abstract class EntityTypeTransform<TEntityType> : IEntityTypeTransform<TEntityType> where TEntityType : class
    {
        public abstract TEntityType Transform(IDataRecord dataRecord);
    }
    public class TaskParameter
    {
        public int TaskId;
        public string Name;
        public string Value;
    }
    public class TaskParameterEntityTypeTransform : EntityTypeTransform<TaskParameter>
    {
        public override TaskParameter Transform(IDataRecord dataRecord)
        {
            return new TaskParameter()
            {
                TaskId = (int)dataRecord["task_id"],
                Name = (string)dataRecord["p_name"],
                Value = (string)dataRecord["p_value"]
            };
        }
    }
    public class SomeClass
    {
        public KeyedByTypeCollection<IEntityTypeTransform<object>> TransformDictionary = new KeyedByTypeCollection<IEntityTypeTransform<object>>()
        {
            new TaskParameterEntityTypeTransform(),
            // More transforms here
        };
    }
