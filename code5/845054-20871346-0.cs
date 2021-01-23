    public abstract class SimpleUrl
    {
        protected string _url;
        public abstract string Url { get; set; }
        // Optionally declare base constructors that do *not* call Url.set
        // Not sure why these constructors are optional in the base, but
        // required in the derivative classes.  But they are.
        public SimpleUrl()
        { }
    }
    public sealed class HttpUrl : SimpleUrl
    {
        public HttpUrl()   // Not sure why this is required, but it is.
        { }
        public HttpUrl(string Url)
        {
            // Since HttpUrl is sealed, the Url set accessor is no longer
            // overridable, which makes the following line safe.
            this.Url = Url;
        }
        public override string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                if (value.StartsWith("http://"))
                    this._url = value;
                else
                    throw new ArgumentException();
            }
        }
    }
