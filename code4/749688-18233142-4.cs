    public struct MyStruct : IComparable<MyStruct>, IComparable, IEquatable<MyStruct>
    {
        public int MyInt1 { get; set; }
        public int MyInt2 { get; set; }
        public int CompareTo(MyStruct other)
        {
            return this.InnerCompareTo(other);
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is MyStruct))
            {
                throw new ArgumentException("obj");
            }
            MyStruct other = (MyStruct)obj;
            return this.InnerCompareTo(other);
        }
        private int InnerCompareTo(MyStruct other)
        {
            int cmp = this.MyInt1.CompareTo(other.MyInt1);
            if (cmp == 0)
            {
                cmp = this.MyInt2.CompareTo(other.MyInt2);
            }
            return cmp;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is MyStruct))
            {
                throw new ArgumentException("obj");
            }
            MyStruct other = (MyStruct)obj;
            return this.InnerEquals(other);
        }
        public bool Equals(MyStruct other)
        {
            return this.InnerEquals(other);
        }
        private bool InnerEquals(MyStruct other)
        {
            return this.MyInt1 == other.MyInt1 && this.MyInt2 == other.MyInt2;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                // From http://stackoverflow.com/a/263416/613130
                int hash = 17;
                hash = hash * 23 + this.MyInt1;
                hash = hash * 23 + this.MyInt2;
                return hash;
            }
        }
        // The != is based on the ==
        public static bool operator ==(MyStruct a, MyStruct b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(MyStruct a, MyStruct b)
        {
            return !(a == b);
        }
        public static bool operator >(MyStruct a, MyStruct b)
        {
            return a.CompareTo(b) > 0;
        }
        // The <, >=, <= are all based on the >
        public static bool operator <(MyStruct a, MyStruct b)
        {
            return b > a;
        }
        public static bool operator >=(MyStruct a, MyStruct b)
        {
            //return !(a < b);
            //We short-circuit the <operator, because we know how it's done
            return !(b > a);
        }
        public static bool operator <=(MyStruct a, MyStruct b)
        {
            return !(a > b);
        }
    }
