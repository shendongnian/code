    public interface IInterface
    {
       int Method(int p);
    }
    public class DefaultImplementation : IInterface
    {
       public int Method(int p)
       {
          return 6;
       }
    }
    [TestFixture]
    public class SomeFixture
    {
       public static void TheMethodITest(IInterface dep)
       {
          for (var i = 0; i < 10; i++)
          {
             Debug.WriteLine("{0}:{1}",i, dep.Method(i));
          }
       }
    } 
