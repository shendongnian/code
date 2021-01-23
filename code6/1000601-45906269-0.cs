    public class MyTestFixture : IAsyncLifetime
    {
    	private string someState;
    
    	public async Task InitializeAsync()
    	{
    		await Task.Run(() => someState = "Hello");
    	}
    
    	public Task DisposeAsync()
    	{
    		return Task.CompletedTask;
    	}
    		
    	[Fact]
    	public void TestFoo()
    	{
    		Assert.Equal("Hello", someState);
    	}
    }
