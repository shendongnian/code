    class Program
    {
        class Comparable1 : IComparable<Comparable1>, IComparable
        {
            private int _value;
            public Comparable1()
            {
                _value = new Random().Next();
            }
            public int CompareTo(Comparable1 other)
            {
                return _value.CompareTo(other._value);
            }
            public int CompareTo(object obj)
            {
                return CompareTo(obj as Comparable1);
            }
        }
        class Comparable2 : IComparable<Comparable2>, IComparable
        {
            private int _value;
            public Comparable2()
            {
                _value = new Random().Next();
            }
            public int CompareTo(Comparable2 other)
            {
                return _value.CompareTo(other._value);
            }
            public int CompareTo(object obj)
            {
                return CompareTo(obj as Comparable2);
            }
        }
        static void Main(string[] args)
        {
            Comparable1 x = new Comparable1();
            Comparable2 y = new Comparable2();
            Stopwatch version1 = Stopwatch.StartNew();
            for (int round = 0; round < 10000000; ++round)
            {
                CompareObjects1(x, y);
            }
            version1.Stop();
            Stopwatch version2 = Stopwatch.StartNew();
            for (int round = 0; round < 10000000; ++round)
            {
                CompareObjects2(x, y);
            }
            version2.Stop();
            Console.WriteLine("Time1=" + version1.ElapsedTicks.ToString() + ", Time2=" + version2.ElapsedTicks.ToString());
        }
        public static int CompareObjects1(object valueX, object valueY)
        {
            IComparable myValueX = valueX as IComparable;
            IComparable myValueY = valueY as IComparable;
            if (myValueX == null)
            {
                if (myValueY == null)
                    return 0;
                return -1;
            }
            if (myValueY == null)
                return 1;
            Type typeX = valueX.GetType();
            Type typeY = valueY.GetType();
            if (!typeX.Equals(typeY))
            {
                return string.CompareOrdinal(typeX.Name, typeY.Name);
            }
            return myValueX.CompareTo(myValueY);
        }
        public static int CompareObjects2(object valueX, object valueY)
        {
            IComparable myValueX = valueX as IComparable;
            IComparable myValueY = valueY as IComparable;
            if (myValueX == null)
            {
                if (myValueY == null)
                    return 0;
                return -1;
            }
            if (myValueY == null)
                return 1;
            Type typeX = valueX.GetType();
            Type typeY = valueY.GetType();
            if (!typeX.Equals(typeY))
            {
                int ret = typeX.GetHashCode().CompareTo(typeY.GetHashCode());
                if (ret != 0) return ret;
                return string.CompareOrdinal(typeX.Name, typeY.Name);
            }
            return myValueX.CompareTo(myValueY);
        }
    }
