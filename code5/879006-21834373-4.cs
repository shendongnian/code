    public ILifetimeScope GetLifetimeScope(Action<ContainerBuilder> configurationAction)
    {
      if (HttpContext.Current == null)
      {
        throw new InvalidOperationException("...");
      }
      // ...and your code is probably dying right there so I won't
      // include the rest of the source.
    }
