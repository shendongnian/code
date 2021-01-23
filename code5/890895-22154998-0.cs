    using (var context = new MyContext())
    {
        var ideation = new Ideation { Id = 1 }; // this is NOT a proxy
        context.Ideations.Attach(ideation);
        // other stuff maybe ...
        var anotherIdeation = context.Ideations.Find(1);
    }
