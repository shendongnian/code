    public string Foo
    {
       get
       {
          return this.foo;
       }
       set
       {
           if (value != this.foo)
           {
              this.foo = value;
              OnPropertyChanged(nameof(MyClass.Foo));
           }
       }
    }
