            Foo nonProxy = new Foo { Id = 4, Name = "Foo 4" }; // values correspond to an existing entity in db
			ApplicationDbContext ctx = new ApplicationDbContext();			
            ctx.Foos.Attach(nonProxy);
            Assert.AreSame(nonProxy, ctx.Foos.Find(nonProxy.Id));
            Assert.AreSame(nonProxy, ctx.Foos.First(c => c.Name == "Foo 4"));
            Assert.AreSame(nonProxy, ctx.Foos.FirstOrDefault(c => c.Name == "Foo 4"));
            Assert.AreSame(nonProxy, ctx.Foos.Single(c => c.Name == "Foo 4"));
            Assert.AreSame(nonProxy, ctx.Foos.SingleOrDefault(c => c.Name == "Foo 4"));
            ctx = new ApplicationDbContext();
            Foo proxy = ctx.Foos.Find(nonProxy.Id);
            Assert.AreSame(proxy, ctx.Foos.Find(nonProxy.Id));
            Assert.AreSame(proxy, ctx.Foos.First(c => c.Name == "Foo 4"));
            Assert.AreSame(proxy, ctx.Foos.FirstOrDefault(c => c.Name == "Foo 4"));
            Assert.AreSame(proxy, ctx.Foos.Single(c => c.Name == "Foo 4"));
            Assert.AreSame(proxy, ctx.Foos.SingleOrDefault(c => c.Name == "Foo 4"));
