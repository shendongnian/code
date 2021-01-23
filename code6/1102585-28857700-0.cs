    public static class FileOrderExtensions
    {
      public static IEnumerable<File> OrderByPredicates(this IEnumerable<File> files, Func<File, bool>[] predicates)
      {
        var lastOrderPredicate = new Func<File, bool>(file => true);
   
        var predicatesWithIndex = predicates
          .Concat(new [] { lastOrderPredicate })
          .Select((predicate, index) => new {Predicate = predicate, Index = index});
   
        return files
          .OrderBy(file => predicatesWithIndex.First(predicateWithIndex => predicateWithIndex.Predicate(file)).Index);
      }
    }
