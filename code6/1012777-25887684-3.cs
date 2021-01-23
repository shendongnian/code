    class B {
    }
 
    class C {
        int Order {get; set;}
        B B {get; set;}
        A A {get; set;}
    }
    
    class A {
        ICollection<C> Cs {get; set;}
    }
    modelBuilder.Entity<C>().HasRequired(x => x.B);
    modelBuilder.Entity<C>().HasRequired(x => x.A).WithMany(y => y.Cs);
