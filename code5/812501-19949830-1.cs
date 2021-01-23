     public interface IExcludeProperties
        {
            Type ExcludeType();
           void  AddPropertyName(string propertyName);
            List<string> GetPropertiesNames();
        }
      public class ExcludeProperties<T> : IExcludeProperties
        {
            HashSet<string> propertiesNames = new HashSet<string>();
    
            List<PropertyInfo> props = new List<PropertyInfo>();
    
    
            public ExcludeProperties()
            {
                props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
            }
    
            public Type ExcludeType()
            {
                return typeof(T);
            }
    
            public void AddPropertyName(string propertyName)
            {
                if(! typeof(T).IsAbstract &&  !props.Any(p=>p.Name==propertyName) )
                    throw new Exception(string.Format("No existe y no por lo tanto no se puede excluir la propiedad {0} para el tipo {1}!",propertyName,typeof(T).Name));
          
              
                  propertiesNames.Add(propertyName);
            }
    
        public List<string> GetPropertiesNames()
        {
            return propertiesNames.ToList();
        }
    }
