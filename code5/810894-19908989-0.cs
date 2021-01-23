    public abstract class EntityModel
    {
    }
    
    public abstract class ViewModel<T>
    	where T : EntityModel
    {
    }
    
    public class ModelMapper<TEM, TVM>
    	where TEM : EntityModel, new()
    	where TVM : ViewModel<TEM>, new()
    {
    	public virtual TVM MapToViewModel(TEM entityModel)
    	{
    		// Default implementation using reflection.
    	}
    
    	public virtual TEM MapToEntityModel(TVM viewModel)
    	{
    		// Default implementation using reflection.
    	}
    }
