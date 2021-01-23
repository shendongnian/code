    void Main()
    {
        Mapper.CreateMap<Parent,ParentDto>().ReverseMap();
        Mapper.CreateMap<Child,ChildDto>().ReverseMap();
        Mapper.AssertConfigurationIsValid();
        
        var par = new Parent { TestProp = new List<Child> 
                               { new Child(),
                                 new Child() 
                               }
                             };
        Mapper.Map<ParentDto>(par).Dump();
        Mapper.Map<Parent>(Mapper.Map<ParentDto>(par)).Dump();
    }
    class Parent
    {
        public List<Child> TestProp{ get; set; }
    }
    class Child {}
    class ParentDto
    {
        public IEnumerable<ChildDto> TestProp{ get; set; }
    }
    class ChildDto {}
