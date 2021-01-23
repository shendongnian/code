    class Base
    {
        public int Counter { get; set; }
        // ...
    }
...
    AutoMapper.Mapper.CreateMap<Base, Foo>();
    Foo foo = AutoMapper.Mapper.Map<Foo>(b);
