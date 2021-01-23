    public class BaseController : Controller
    {
    	/// <summary>
    	/// Prepares a new MyVM by filling the common properties.
    	/// </summary>
    	/// <returns>A MyVM.</returns>
    	protected MyVM PrepareViewModel()
    	{
    		return new MyVM()
    		{
    			FooDll = GetFooSelectList();
    		}
    	}
    
    	/// <summary>
    	/// Prepares the specified MyVM by filling the common properties.
    	/// </summary>
    	/// <param name="myVm">The MyVM.</param>
    	/// <returns>A MyVM.</returns>
    	protected MyVM PrepareViewModel(MyVM myVm)
    	{
    		myVm.FooDll = GetFooSelectList();
    		return myVm;
    	}
    	
    	/// <summary>
    	/// Fetches the foos from the database and creates a SelectList.
    	/// </summary>
    	/// <returns>A collection of SelectListItems.</returns>
    	private IEnumerable<SelectListItem> GetFooSelectList()
    	{
    		return fooRepository.GetAll().ToSelectList(foo => foo.Id, foo => x.Name);
    	}
    }
