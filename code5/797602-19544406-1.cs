    public abstract class EntityTypeTransformBase
    {
    	public abstract Func<IDataRecord, object> GetDataTransform();
    }
    
    public abstract class EntityTypeTransform<TEntityType> : EntityTypeTransformBase where TEntityType : class
    {
        public abstract Func<IDataRecord, TEntityType> GetDataTransformImpl();
    	
    	public override Func<IDataRecord, object> GetDataTransform()
    	{
    		return GetDataTransformImpl();
    	}
    }
    
    public class TaskParameterEntityTypeTransform : EntityTypeTransform<TaskParameter>
    {
        public override Func<IDataRecord, TaskParameter> GetDataTransformImpl()
        {
            return dataRecord => new TaskParameter()
            {
                TaskId = (int)dataRecord["task_id"],
                Name = (string)dataRecord["p_name"],
                Value = (string)dataRecord["p_value"]
            };
        }
    }
