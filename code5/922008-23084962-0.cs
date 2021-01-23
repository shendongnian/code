    class Program
    {
        static void Main()
        {
            ServiceReference sr = new ServiceReference();
            var listWithWhereCondition = from s in sr where s.Name == "Name2" select s;
            foreach (var item in listWithWhereCondition)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
    public class TestClass
    {
        public string Name { get; set; }
    }
    public class ServiceReference : IEnumerable<TestClass>
    {
        private IEnumerable<TestClass> _testList;
        public ServiceReference()
        {
            _testList = new List<TestClass> { 
                new TestClass {
                    Name = "Name1"
                },
                new TestClass {
                    Name = "Name2"
                },
                new TestClass {
                    Name = "Name2"
                }
            };
        }
        public IEnumerator<TestClass> GetEnumerator()
        {
            foreach (var item in _testList)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
