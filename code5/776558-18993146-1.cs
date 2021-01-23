    public class BaseResponse
    {
        protected virtual string hrefPath
        {
            get { return ""; }
        }
        public string Id { get; set; }
        public string href { get { return hrefPath + Id; } }
    }
