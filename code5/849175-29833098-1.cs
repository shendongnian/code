    {
        ...
        Mapper.CreateMap<InnerValue, DestinationClass>(MemberList.Source);
        Mapper.CreateMap<SourceClass, DestinationClass>(MemberList.Source)
              .ConstructUsing(s => Mapper.Map<DestinationClass>(s.Inner))
              .ForSourceMember(m => m.Inner, opt => opt.Ignore());
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
