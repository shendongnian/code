    namespace SimpleHashNamespace
    {
        public class SimpleHash
        {
            private readonly List<int> _data;
            public SimpleHash(List<int> col2)
            {
                _data = col2;
            }
    
            public int GetMyHash()
            {
                _data.Sort();
                string stringHash = string.Join("", _data);
                return int.Parse(stringHash);   // warning 1: assumes you always have a convertible value
            }
        }
    
        public class MyDataSet
        {
            private readonly List<int> _dataSetValues;
    
            public MyDataSet(List<int> dataSetValues)
            {
                _dataSetValues = dataSetValues;
            }
    
            public override int GetHashCode()
            {
                SimpleHash simpleHash = new SimpleHash(_dataSetValues);
                return simpleHash.GetMyHash();   // warning 2: assumes the computed hash can fit into the int datatype given that GetHashCode() has to return int 
            }
        }
    
        public partial class Program
        {
            private static void Main(string[] args)
            {
                // how you split up Col1 to get your list of int's dataset is up to you
                var myDataSet1 = new MyDataSet(new List<int>(new int[] { 1,2,3 }));
                Console.WriteLine(myDataSet1.GetHashCode());
    
                var myDataSet2 = new MyDataSet(new List<int>(new int[] { 2,1,3 }));
                Console.WriteLine(myDataSet2.GetHashCode());
    
                var myDataSet3 = new MyDataSet(new List<int>(new int[] { 3,2,1 }));
                Console.WriteLine(myDataSet3.GetHashCode());
    
                Console.ReadLine();
            }
        }
    }
