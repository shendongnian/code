    public class SubstitutedClass
    {
        public virtual int SubstitutedProperty { get { throw new InvalidOperationException(); }  }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test2 = Substitute.For<SubstitutedClass>();
            test2.SubstitutedProperty.Returns(10);
            Console.WriteLine(test2.SubstitutedProperty);
        }
    }
