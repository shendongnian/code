    public abstract class Writer<T>        
    {
        private readonly string _url;
        public Writer(string url)
        {
            _url = url;            
        }
        public void Write()
        {
            var jStr = GetJSONString(_url);
            var jArr = JArray.Parse(jStr);
            var tTypes = new List<T>();
            foreach (dynamic d in jArr)            
                tTypes.Add(Parse(d));           
            // other logic here            
        }
        protected abstract T Parse(object d); // implemented by concrete writers
        private string GetJSONString(string url)
        {
            // getting json string here
        }
    }
