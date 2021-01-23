    SitecoreType<IWhatever> sitecoreType = new SitecoreType<IWhatever>();
    sitecoreType.Delegate(y => y.Url).GetValue(GetLazyUrl);
    private LazyString GetLazyUrl(SitecoreDataMappingContext arg)
    {
        var item = context.Item;
        
        return new LazyString(
            () => 
            {
               // the necessary actions to get the url
            });
    }
    public class LazyString : Lazy<string>
    {
        public LazyString(Func<string> valueFactory) : base(valueFactory)
        {
        }
        public override string ToString()
        {
            return Value;
        }
        public static implicit operator string(LazyString lazyString)
        {
            return lazyString.Value;
        }
    }
