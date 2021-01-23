    public class ApplyApiKeySecurity : IDocumentFilter, IOperationFilter
    {
        public ApplyApiKeySecurity(string key, string name, string description, string @in)
        {
            Key = key;
            Name = name;
            Description = description;
            In = @in;
        }
    
        public string Description { get; private set; }
    
        public string In { get; private set; }
    
        public string Key { get; private set; }
    
        public string Name { get; private set; }
    
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, System.Web.Http.Description.IApiExplorer apiExplorer)
        {
            IList<IDictionary<string, IEnumerable<string>>> security = new List<IDictionary<string, IEnumerable<string>>>();
            security.Add(new Dictionary<string, IEnumerable<string>> {
                {Key, new string[0]}
            });
    
            swaggerDoc.security = security;
        }
    
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, System.Web.Http.Description.ApiDescription apiDescription)
        {
            operation.parameters = operation.parameters ?? new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = Name,
                description = Description,
                @in = In,
                required = true,
                type = "string"
            });
        }
    
        public void Apply(Swashbuckle.Application.SwaggerDocsConfig c)
        {
            c.ApiKey(Key)
                .Name(Name)
                .Description(Description)
                .In(In);
            c.DocumentFilter(() => this);
            c.OperationFilter(() => this);
        }
    }
