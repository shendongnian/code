    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using NUnit.Framework;
    namespace System
    {
        [TestFixture]
        public class SettableTests
        {
            Settable<int> i;
            [SetUp]
            public void ResetValue()
            {
                i = default(Settable<int>);
            }
            [Test]
            public void TestUndefined()
            {
                Assert.That(i.IsSet, Is.False);
                Assert.That(i.HasValue, Is.False);
                Assert.Throws<InvalidOperationException>(() => { var a = i.Value; });
            }
            [Test]
            public void TestNullValue()
            {
                i = null;
                Assert.That(i.IsSet, Is.True);
                Assert.That(i.HasValue, Is.False);
                Assert.Throws<InvalidOperationException>(() => { var a = i.Value; });
            }
            [Test]
            public void TestIntValues()
            {
                i = 10;
                Assert.That(i.IsSet, Is.True);
                Assert.That(i.HasValue, Is.True);
                Assert.That(i.Value, Is.EqualTo(10));
            }
            public class Tmp
            {
                public Settable<int> A { get; set; }
                public Settable<int> B { get; set; }
            }
            [Test]
            [TestCase("{A:10}", true, true, 10, false, false, null)]
            [TestCase("{A:10, B:null}", true, true, 10, true, false, null)]
            [TestCase("{}", false, false, null, false, false, null)]
            [TestCase("{A:10, B:5}", true, true, 10, true, true, 5)]
            [TestCase("{B:null}", false, false, null, true, false, null)]
            public void TestDeserialization(string json,
                bool aIsSet, bool aHasValue, int? aValue,
                bool bIsSet, bool bHasValue, int? bValue)
            {
                var o = JsonConvert.DeserializeObject<Tmp>(json);
                Assert.That(o.A.IsSet, Is.EqualTo(aIsSet));
                Assert.That(o.A.HasValue, Is.EqualTo(aHasValue));
                if (aValue != null)
                    Assert.That(o.A.Value, Is.EqualTo(aValue));
                Assert.That(o.B.IsSet, Is.EqualTo(bIsSet));
                Assert.That(o.B.HasValue, Is.EqualTo(bHasValue));
                if (bValue != null)
                    Assert.That(o.B.Value, Is.EqualTo(bValue));
            }
            public object[] SerializationTests = {
                new object[] {new Settable<int>(1), "1"},
                new object[] {new Settable<int>(null), "null"},
                new object[] {Settable<int>.Undefined, "null"},
                new object[] {new Settable<int>(10), "10"},
                new object[] {new Settable<int>(-10000), "-10000"},
                new object[] {Settable<bool>.Undefined, "null"},
                new object[] {new Settable<bool>(null), "null"},
                new object[] {new Settable<bool>(true), "true"},
                new object[] {new Settable<bool>(false), "false"},
                new object[] {Settable<double>.Undefined, "null"},
                new object[] {new Settable<double>(null), "null"},
                new object[] {new Settable<double>(0), "0.0"},
                new object[] {new Settable<double>(-10.53), "-10.53"},
            };
            [Test]
            [TestCaseSource("SerializationTests")]
            public void TestSerialization(Object v, string expectedJson)
            {
                var json = JsonConvert.SerializeObject(v);
                Assert.That(json, Is.EqualTo(expectedJson));
            }
            public object[] EqualityCases = {
                new object[] {Settable<int>.Undefined, Settable<int>.Undefined, true},
                new object[] {Settable<int>.Undefined, new Settable<int>(null), false},
                new object[] {new Settable<int>(0), Settable<int>.Undefined, false},
                new object[] {new Settable<int>(null), new Settable<int>(null), true},
                new object[] {new Settable<int>(null), new Settable<int>(10), false},
                new object[] {new Settable<int>(0), new Settable<int>(10), false},
                new object[] {new Settable<int>(-1), new Settable<int>(-1), true},
                new object[] {new Settable<int>(0), new Settable<int>(0), true}
            };
            [Test]
            [TestCaseSource("EqualityCases")]
            public void TestEquality(Settable<int> a, Settable<int> b, bool expected)
            {
                Assert.That(a == b, Is.EqualTo(expected));
            }
            [Test]
            [TestCaseSource("EqualityCases")]
            public void TestInequality(Settable<int> a, Settable<int> b, bool expected)
            {
                Assert.That(a != b, Is.EqualTo(!expected));
            }
        }
    }
