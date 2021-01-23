    public abstract class BaseModel
    {
       private ModelStateDictionary _modelState = new ModelStateDictionary();
       public ModelStateDictionary ModelState
       {
          get
          {
             return _modelState;
          }
          set
          {
             _modelState = value;
          }
       }
    }
