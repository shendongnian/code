    public interface I {
      string AnotherProperty { get; }
    }
  
    public class A {
      public string Name { get; set; }
      public string Id { get; set; }
    }
    public class B : A, I {
      public string AnotherProperty { get; set; }
    }
    public static class BExtensions {
      public static B[] FromAArray(this A[] array) {
        var bList = new List<B>();
        foreach (var a in array) {
          bList.Add(new B() { Id = a.Id, Name = a.Name, AnotherProperty = String.Empty });
        }
        return bList.ToArray();
      }
    }
    class Program {
      static void Main(string[] args) {
        A[] baseClassList = { new A { Name = "Bob", Id = "1" }, new A { Name = "Smith", Id = "2"}};
        B[] derivedClassList = baseClassList.FromAArray();
      }
    }
