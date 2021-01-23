    public interface ITestApplicationService
    {
    	IQueryable<TestViewModel> GetModelList(SomeFilter filter, UrlHelper url);
    	void Save(TestViewModel model);
    	void Delete(int id);
    }
    
    public class TestApplicationService
    {
    	private readonly ITestRepository repository;
    	
    	public TestApplicationService(ITestRepository repository)
        {
            this.repository = repository;
        }
    	
    	public IQueryable<TestViewModel> GetModelList(SomeFilter filter, UrlHelper url)
    	{
    	   var viewModelList = repository.GetTestEntityBy(filter.TestId, filter.Name) // returns IQueryable<TestEntity>
    		.Select(x => new TestViewModel // linq projection - mapping into the list of viewModel
    		{
    			Id = x.Id,
    			Name = SomeFormatter.FormatName(
    				x.TestId,
    				x.TestAddress1,
    				x.TestAddress2),
    			Url = UrlFormatter.Format(x.TestName, url.Action("ChangeValue", "TestController", new { x.id })),
    			AllergyType = x.TestType
    			Notes = x.Notes,
    			...
    		});
    		
    		return viewModelList;
    	}
    	...
    }
