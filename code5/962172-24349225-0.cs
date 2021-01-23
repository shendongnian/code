    class Visitor {
       public virtual void Visit(FeeType f) {}
       public virtual void Visit(OtherType t) {}
    }
    
    class abstract BaseType { public abstract void Accept(Visitor v); }
    
    class FeeType : BaseType {
       public override void Accept(Visitor v) { v.Visit(this); }
    }
    
    class OtherType : BaseType {
       public override void Accept(Visitor v) { v.Visit(this); }
    }
    
    class DIVisitor : Visitor {
       public virtual void Visit(FeeType f) { f.KeyHolder = new ... }
       public virtual void Visit(OtherType t) { t.KeyHolder = new ... }
    }
    public void AttachKeyHolder(ILocalizableEntity localizableEntity)
    {
       var ft = (localizableEntity as TypeBase);
       ft.Accept(new DIVisitor());
    }
