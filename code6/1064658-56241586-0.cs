[assembly: CollectionBehavior(DisableTestParallelization = true)]
and they'll run sequentially.
**NOTE:**
Ideally this should be avoided because there's great interest in designing your tests and code in a way that it's idempotent and stateless, in fact I use all my tests as a subclass of this, to have a nice Given Then When structure:
public abstract class Given_When_Then_Test
	: IDisposable
{
	protected Given_When_Then_Test()
	{
		Setup();
	}
	private void Setup()
	{
		Given();
		When();
	}
	protected abstract void Given();
	protected abstract void When();
	public void Dispose()
	{
		Cleanup();
	}
	protected virtual void Cleanup()
	{
	}
}
Things I've discovered:
1. I have experienced errors in the integration tests running in parallel when I use `IContainer` of Autofac to resolve services instead resolving first `IComponentContext` and then resolving my services with it.
