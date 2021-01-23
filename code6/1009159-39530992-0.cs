    > public abstract class Base : IBase
    >     {
    > 
    >         private IDep dep;
    > 
    >         [InjectionMethod]
    >         public void Initialize(IDep dep)
    >         {
    >             if (dep == null) throw new ArgumentNullException("dep");
    >             this.dep = dep;
    > 
    >             OnInitialize();
    >         }
    > 
    >         public dep DepProperty
    >         {
    >             get
    >             {
    >                 return dep;
    >             }
    >         }
    >         protected abstract void OnInitialize();
    >     }
