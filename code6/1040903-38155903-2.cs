    public class MyModelSettings : SerializationSettings<MyModel> 
    {
        public MyModelSettings() 
        {
            RuleFor(x => x.Id).Name("Identifier");
            RuleFor(x => x.SomeObj).Name("Data").Converter(new SomeObjConverter());
            RuleFor(x => x.Name).Ignore();
        }
    }
