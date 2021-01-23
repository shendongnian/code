    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Number: IComparable<Number>, IComparable
        {
            public Number(int value)
            {
                Value = value;
            }
            public readonly int Value;
            public int CompareTo(Number other)
            {
                return Value.CompareTo(other.Value);
            }
            public int CompareTo(object obj)
            {
                return CompareTo((Number) obj);
            }
        }
        class Test
        {
            public Number Number;
            public object Obj
            {
                get { return Number; }
            }
            public override string ToString()
            {
                return Number.Value.ToString();
            }
        }
    
        internal static class Program
        {
            static void Main()
            {
                var itemProp = typeof(Test).GetProperty("Obj");
                Console.WriteLine(string.Join("\n",
                    data().OrderBy(x => itemProp.GetValue(x, null))));
            }
            static IEnumerable<Test> data()
            {
                for (int i = 0; i < 10; ++i)
                    yield return new Test {Number = new Number(10-i)};
            }
        }
    }
