    // DbSet property in your DbContext
    public DbSet<MyClass2> Classes { get; set; }
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
    public class MyClass2 :  MyClass
    {
        public virtual List<MyDerivedClass> DerivedObjects
        {
            get
            {
                for( int i = 0; i < Objects.Count; ++i )
                {
                    var o = Objects[i];
                    if( null == ( o as MyDerivedClass ) )
                    {
                        Objects[ i ] = new MyDerivedClass( o );
                    }
                }
                return Objects.Cast<MyDerivedClass>().ToList();
            }
            set
            {
                Objects = value.Cast<MyBaseClass>().ToList();
            }
        }
    }
