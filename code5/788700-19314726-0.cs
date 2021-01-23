    public interface IProvider { }
    public abstract class BaseProvider : IProvider { }
    public class Provider1 : BaseProvider { }
    public class Provider2 : BaseProvider { }
    [Test]
    public void RegisterTwoImplementations_GetAllInstances_ReturnsBothInstances()
    {
        SimpleIoc.Default.Register<Provider1>();
        SimpleIoc.Default.Register<Provider2>();
        SimpleIoc.Default.Register<BaseProvider>(() => 
                SimpleIoc.Default.GetInstance<Provider1>(), "a" );
        SimpleIoc.Default.Register<BaseProvider>(() =>
                SimpleIoc.Default.GetInstance<Provider2>(), "b");
        var result = SimpleIoc.Default.GetAllInstances<BaseProvider>();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.Any(x => x.GetType() == typeof(Provider1)), Is.True);
        Assert.That(result.Any(x => x.GetType() == typeof(Provider2)), Is.True);
    }
