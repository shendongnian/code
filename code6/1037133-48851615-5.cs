    public class MySerializerProvider: DefaultODataSerializerProvider
    {
        private readonly Dictionary<string, ODataEdmTypeSerializer> _EntitySerializers;
        public SerializerProvider()
        {
            _EntitySerializers = new Dictionary<string, ODataEdmTypeSerializer>();
            _EntitySerializers[typeof(MyObj).FullName] = new MyObjEntitySerializer(this);
            //etc 
        }
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.IsEntity())
            {
                string stripped_type = StripEdmTypeString(edmType.ToString());
                if (_EntitySerializers.ContainsKey(stripped_type))
                {
                    return _EntitySerializers[stripped_type];
                }
            }            
            return base.GetEdmTypeSerializer(edmType);
        }
        private static string StripEdmTypeString(string t)
        {
            string result = t;
            try
            {
                result = t.Substring(t.IndexOf('[') + 1).Split(' ')[0];
            }
            catch (Exception e)
            {
                //
            }
            return result;
        }
    }
