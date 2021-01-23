    class Equalitycompare<T> : IEqualityComparer<T>
    {
        Func<T, T, bool> _equalsFunction;
        Func<T, int> _hashCodeFunction;
        public Equalitycompare( Func<T, T, bool> equalsFunction, Func<T, int> hashCodeFunction)
        {
            if (equalsFunction == null) throw new ArgumentNullException();
            if (hashCodeFunction == null) throw new ArgumentNullException();
 
         _equalsFunction = equalsFunction;
         _hashCodeFunction = hashCodeFunction;
        }
        public bool Equals(T x, T y)
        {
            return _equalsFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _hashCodeFunction(obj);
        }
    }
     static void Main(string[] args)
     {
        Student Student1 = new Student();
        Student1.ID = 1;
        Student Student2 = new Student();
        Student2.ID = 1;
        Student Student3 = new Student();
        Student3.ID = 3;
        var comparer = new Equalitycompare<Student>((x, y) => x.ID == y.ID, x =>           x.ID.GetHashCode());
       var students = new List<Student>{Student1,Student2,Student3};
       var uniquestudents = students.Distinct(comparer);
     }
