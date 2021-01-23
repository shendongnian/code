    /// <summary>
    /// Inherits from table service entity
    /// </summary>
    public class BaseModel
    {
    
        public BaseModel()
        {
        }
    
        public BaseModel(TableServiceEntity entity)
        {
            this.Entity = entity;
        }
    
        protected TableServiceEntity Entity { get; set; }
    }
    
    /// <summary>
    /// Inherits from base model
    /// </summary>
    public class Business : BaseModel
    {
    
    }
