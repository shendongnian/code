          private static readonly Program p = new Program();
    
          private Foo foo;
    
          static void Main(string[] args) {
             p.foo = new Foo();
             p.foo.IsFoo = true;
             p.foo.IsIFoo = true;
    
             // uses Transact(Func<Foo, bool> funcBlock)
             var isFoo = p.Transact(f => f.IsFoo == true);
             Console.WriteLine("isFoo: {0}", isFoo);
    
             //  this is ambiguous
             //var isIFoo = p.Transact(f=> (f as IFoo).IsIFoo == true);
    
             // this works
             var isIFoo = p.Transact((IFoo f) => f.IsIFoo == true);
             Console.WriteLine("isIFoo: {0}", isIFoo);
    
    
             Console.ReadLine();
          }
    
          bool Transact(Func<Foo, bool> funcBlock) {
             Console.WriteLine("Transact(Func<Foo, bool> funcBlock)");
    
             return (funcBlock(p.foo));
          }
    
          bool Transact(Func<IFoo, bool> funcBlock) {
             Console.WriteLine("Transact(Func<IFoo, bool> funcBlock)");
    
             return (funcBlock(p.foo));
          }
       }
    
       class Foo : IFoo {
    
          public bool IsFoo {
             get;
             set;
          }
    
          public bool IsIFoo {
             get;
             set;
          }
    
       }
    
       interface IFoo {
    
          bool IsIFoo { get; set; }
       }
