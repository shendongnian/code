    public class MyWrappingClass
    {
        public IEnumerable<AttributeCollection> allAttributes { get; set; }
    }
    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
        if ((typeof(IEnumerable<AttributeCollection>).IsAssignableFrom(type)))
        {
            var list = (IEnumerable<AttributeCollection>)value;
            var obj = new MyWrappingClass { allAttributes = list };
            return base.WriteToStreamAsync(obj.GetType(), obj, writeStream, content, transportContext);
        }
        else
        {
            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
