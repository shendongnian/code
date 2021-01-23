      public class DefaultAssembliesResolver : IAssembliesResolver {    
        public virtual ICollection<Assembly> GetAssemblies() {
          return (ICollection<Assembly>) Enumerable.ToList<Assembly>((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies());
        }
      }
