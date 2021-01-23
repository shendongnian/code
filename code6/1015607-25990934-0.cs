    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace LimitingUseOfValueTypeAsDictionaryKey
    {
        public struct MySpecialInt
        {
            public int Target;
    
            public MySpecialInt(int source)
            {
                if (source == 123)
                {
                    throw new ArgumentOutOfRangeException("source");
                }
                Target = source;
            }
    
            public static implicit operator int(MySpecialInt source)
            {
                return source.Target;
            }
    
            public static implicit operator MySpecialInt(int source)
            {
                return new MySpecialInt(source);
            }
        }
    
        public class LimitingIntComparer : IEqualityComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
    
            public bool Equals(int x, int y)
            {
                return x.Equals(y);
            }
    
            public int GetHashCode(int source)
            {
                if (source == 123)
                {
                    throw new ArgumentOutOfRangeException("source");
                }
                return source.GetHashCode();
            }
        }
    
        public class LimitingStringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return object.Equals(x, y);
            }
    
            public int GetHashCode(string source)
            {
                if (source == "123")
                {
                    throw new ArgumentOutOfRangeException("source");
                }
                return source.GetHashCode();
            }
        }
    
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void CanTreatMySpecialIntAsRegularInt()
            {
                var a = 1;
                MySpecialInt b = a;
                Assert.AreEqual((int)b, 1);
            }
    
            [TestMethod]
            public void CanUseOnlyAllowedValuesAsAKeyUsingCustomStruct()
            {
                var d = new Dictionary<MySpecialInt, string>();
                d.Add(1, "foo");
    
                try
                {
                    d.Add(123, "bar");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Can't do that");
                }
    
                Assert.AreEqual(1, d.Count);
                Assert.AreEqual("foo", d[1]);
            }
    
            [TestMethod]
            public void CanUseOnlyAllowedValuesAsAKeyUsingUsingComparer()
            {
                var d = new Dictionary<int, string>(new LimitingIntComparer());
                d.Add(1, "foo");
    
                try
                {
                    d.Add(123, "bar");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Can't do that");
                }
    
                Assert.AreEqual(1, d.Count);
                Assert.AreEqual("foo", d[1]);
            }
    
            [TestMethod]
            public void CanUseOnlyAllowedValuesAsAKeyUsingUsingComparerForStrings()
            {
                var d = new Dictionary<string, string>(new LimitingStringComparer());
                d.Add("1", "foo");
    
                try
                {
                    d.Add("123", "bar");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Can't do that");
                }
    
                Assert.AreEqual(1, d.Count);
                Assert.AreEqual("foo", d["1"]);
            }
        }
    }
