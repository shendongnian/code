    using Autofac;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class UnitTest1
    {
       [TestMethod]
       public void Test1()
       {
          var builder = new ContainerBuilder();
          builder.RegisterType<AutoComplete>()
                 .WithParameter((pi, c) => pi.ParameterType == typeof(SearchType),
                                (pi, c) => SearchType.Document);
          var container = builder.Build();
          var autoComplete = container.Resolve<AutoComplete>();
          Assert.AreEqual(SearchType.Document, autoComplete.SearcherType);
       }
    }
    
    public class AutoComplete
    {
       public AutoComplete(SearchType searcherType)
       {
          SearcherType = searcherType;
       }
       public SearchType SearcherType { get; private set; }
    }
    
    public enum SearchType
    {
       Document,
       PageSearch,
    }
