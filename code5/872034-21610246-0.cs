    public class MyClass
    {
     IUnityContainer _container;
     public MyClass(IMyDependentInterface dpenedentclass, IUnityContainer container)
     {
     _container = container;
     //........
     }
    
     public void DoSomething()
     {
      var obj = _container.Resolve<ISomeOtherInterface>();
      obj.DoAction();    
     }    
    }
