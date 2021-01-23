    public virtual void Save()
    {
      using(Transaction t = new Transaction())
      {
         foreach(AnotherClass a in this.SomeObjects??new AnotherClass[]{})
         {
           a.Parent = this;
           a.Save();
         }
         base.Save();
      }
    }
