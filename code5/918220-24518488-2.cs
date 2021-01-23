      public class DefaultAssembliesResolver : IAssembliesResolver {    
        public virtual ICollection<Assembly> GetAssemblies() {
          return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
      }
