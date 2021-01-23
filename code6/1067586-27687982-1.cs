    public class MyPocoEntitiyTypeConfig<T> : EntityTypeConfiguration<T> where T:class
    {
       
    }
    public class MyPocoEnt
    {
        public virtual string MyProp { get; set; }
    }
    public class MyPocoEntMapping : MyPocoEntitiyTypeConfig<MyPocoEnt>
    {
        public MyPocoEntMapping()
        {
                Property(x => x.MyProp).HasMaxLength(300);
                Property(x => x.MyProp).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("MyProp") { IsUnique = true }));
            }
        }
    }
