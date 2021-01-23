    interface IContext
    {
      IDbSet<Foo> Foos { get; set; }
    }
    
    var context = Substitute.For<IContext>();
    
    context.Foos.Returns(new MockDbSet<Foo>());
