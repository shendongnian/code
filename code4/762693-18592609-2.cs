    class foo
    {
       protected foo() 
       { 
          // default constructor which is protected, so not useable from the 'outside' 
       }
       
       public foo( Guid g ) 
       {}
    
       public foo( Guid g, bool b) : this(g) 
       {}
       public virtual void GenX() {}
    }
    
    class bar : foo
    {
       public bar( Guid g, bool b) : base()
       {}
       public override void GenX() {}
    }
