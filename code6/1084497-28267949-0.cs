    namespace SO28254462
    {
        class Program
        {
            class Customer
            {
                private readonly Foo foo = new Foo();
    
                public string name;
    
                public Customer()
                {
                }
    
                public Customer(string id)
                {
                    this.ID = id;
                }
    
                public string ID { get; set; }
    
                public Foo Foo
                {
                    get
                    {
                        return this.foo;
                    }
                }
            }
    
            class Foo
            {
                public string Bar { get; set; }
            }
    
            static void Main(string[] args)
            {
                Customer c1 = new Customer { };
    
                Customer c2 = new Customer();
    
                Customer c3 = new Customer { name = "John", ID = "ABC", Foo = { Bar = "whatever" } };
    
                Customer c4 = new Customer();
                c4.name = "John";
                c4.ID = "ABC";
                c4.Foo.Bar = "whatever";
    
                Customer c5 = new Customer("ABC") { name = "John", Foo = { Bar = "whatever" } };
    
                Customer c6 = new Customer("ABC");
                c6.name = "John";
                c6.Foo.Bar = "whatever";
            }
        }
    }
