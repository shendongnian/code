    {
        ...
        Mapper.CreateMap<InnerValue, DestinationClass>();
        Mapper.CreateMap<SourceClass, DestinationClass>()
              .ConstructUsing(s => Mapper.Map<DestinationClass>(s.Inner));
        ...
    }
    
    public class DestinationClass
    {
        public int InnerPropertyId { get; set; }
        public string StringValue { get; set; }
        public string SourceClassValue { get; set; }
    }
    
    public class SourceClass
    {
        public string SourceClassValue { get; set; }
        public InnerValue Inner { get; set; }
    }
    
    public class InnerValue
    {
        public int InnerPropertyId { get; set; }
        public string StrignValue {get;set;}
    }
