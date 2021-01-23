         public class IgnoreHttpRequestMessageOperationFilter : IOperationFilter
      {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, 
                          ApiDescription apiDescription)
        {
          apiDescription.ParameterDescriptions
            .Where(desc => desc.ParameterDescriptor.ParameterType 
                == typeof(HttpRequestMessage))
            .ToList()
            .ForEach(param =>
            {
              var toRemove = operation.parameters
                .SingleOrDefault(p => p.name == param.Name);
    
              if (null != toRemove)
                operation.parameters.Remove(toRemove);
            });
        }
      }
