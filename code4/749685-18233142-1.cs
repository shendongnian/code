    public class MyClass : IComparable<MyClass>, IComparable, IEquatable<MyClass>
    {
        public int MyInt1 { get; set; }
        public int MyInt2 { get; set; }
        public int CompareTo(MyClass other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.InnerCompareTo(other);
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            MyClass other = obj as MyClass;
            if (object.ReferenceEquals(other, null))
            {
                throw new ArgumentException("obj");
            }
            return this.InnerCompareTo(other);
        }
        private int InnerCompareTo(MyClass other)
        {
            // Here we know that other != null;
            if (object.ReferenceEquals(this, other))
            {
                return 0;
            }
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
            MyClass other = obj as MyClass;
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        public bool Equals(MyClass other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        private bool InnerEquals(MyClass other)
        {
            // Here we know that other != null;
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
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
        public static bool operator==(MyClass a, MyClass b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            return a.InnerEquals(b);
        }
        // The != is based on the ==
        public static bool operator!=(MyClass a, MyClass b)
        {
            return !(a == b);
        }
        public static bool operator>(MyClass a, MyClass b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return false;
            }
            return a.CompareTo(b) > 0;
        }
        // The <, >=, <= are all based on the >
        public static bool operator <(MyClass a, MyClass b)
        {
            return b > a;
        }
        public static bool operator >=(MyClass a, MyClass b)
        {
            //return !(a < b);
            //We short-circuit the <operator, because we know how it's done
            return !(b > a);
        }
        public static bool operator <=(MyClass a, MyClass b)
        {
            return !(a > b);
        }
    }
