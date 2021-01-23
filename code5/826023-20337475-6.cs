    // DbSet property in your DbContext
    public DbSet<MyClass2> Classes { get; set; }
    // continue to ignore MyBaseClass
    ...
    modelBuilder.Ignore<MyBaseClass>();
    ...
    public class MyBaseClass // From external assembly
    {
        //public int ID { get; set; }
        public string Name { get; set; }
    }
    public class MyDerivedClass : MyBaseClass
    {
        public Guid MyID { get; set; }
        public MyDerivedClass()
        {
            MyID = Guid.NewGuid();
        }
        public MyDerivedClass( MyBaseClass myBaseClass ) : this()
        {
            // map myBaseClass to `this` here:
            this.Name = myBaseClass.Name;
        }
    }
    public class MyClass
    {
        public int ID { get; set; }
        public List<MyBaseClass> Objects { get; set; }
    }
    public class MyClass2
    {
        public static implicit operator MyClass( MyClass2 mc2 )
        {
            return mc2._myClass;
        }
        public virtual List<MyDerivedClass> Objects
        {
            get
            {
                for( int i = 0; i < _myClass.Objects.Count; ++i )
                {
                    var o = _myClass.Objects[ i ];
                    if( null == ( o as MyDerivedClass ) )
                    {
                        _myClass.Objects[ i ] = new MyDerivedClass( o );
                    }
                }
                return _myClass.Objects.Cast<MyDerivedClass>().ToList();
            }
            set
            {
                _myClass.Objects = value.Cast<MyBaseClass>().ToList();
            }
        }
        public int ID
        {
            get { return _myClass.ID; }
            set { _myClass.ID = value; }
        }
        private MyClass _myClass;
        public MyClass2()
        {
            _myClass = new MyClass();
        }
        public MyClass2( MyClass myClass )
        {
            if( null == myClass )
                throw new ArgumentNullException( "myClass" );
            _myClass = myClass;
        }
    }
