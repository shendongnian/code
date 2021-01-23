    public class IntegerDatasourceInstanceOptions
    {
        public int Start { get; set; }
        public int Count { get; set; }
    
        public IntegerDatasourceInstanceOptions()
        {
    
        }
    
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    
        public static IntegerDatasourceInstanceOptions Create(string config)
        {
            return JsonConvert.DeserializeObject<IntegerDatasourceInstanceOptions>(config);
        }
    
    }
