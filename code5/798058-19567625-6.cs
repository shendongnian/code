    //In Configure()
    Mapper.CreateMap<string,Member>().ConvertUsing<KeyToBaseConverter<Member>>();
    Mapper.CreateMap<Member, string>().ConvertUsing<BaseToKeyConverter<Member>>();
    public class KeyToBaseConverter<T> : ITypeConverter<string, T> where T : AceOfBase
    {
        public RedisRepository Repository { get; set; }
        public T Convert(ResolutionContext context)
        {
            return Repository.GetByKey<T>(context.SourceValue.ToString());
        }
    }
    public class BaseToKeyConverter<T> : ITypeConverter<T, string> where T : AceOfBase
    {
        public string Convert(ResolutionContext context)
        {
            var f = context.SourceValue as AceOfBase;
            return f.Key;
        }
    }
