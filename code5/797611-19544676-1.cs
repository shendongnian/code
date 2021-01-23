    public interface IEntityTypeTransform
    {
        Func<IDataRecord, object> GetDataTransform();
    }
    public abstract class EntityTypeTransform<T> : IEntityTypeTransform
    {
        public abstract Func<IDataRecord, object> GetDataTransform();
    }
    public class TaskParameterEntityTypeTransform : EntityTypeTransform<TaskParameter>
    {
        public override Func<IDataRecord, object> GetDataTransform()
        {
            return dataRecord => new TaskParameter()
            {
                TaskId = (int)dataRecord["task id"],
            };
        }
    }
