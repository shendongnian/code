    public static class Extensions {
      public static void ProcessContext<TContext>(this IHasContext<TContext> t)
        where TContext : class {
        //...
      }
    }
