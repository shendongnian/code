    public class SimpleWorkerRequestHelper : SimpleWorkerRequest
    {
        /// <summary>
        /// Whether the request is secure
        /// </summary>
        private string _domain;
        /// <summary>
        /// Whether the request is secure
        /// </summary>
        private string _locale;
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWorkerRequestHelper" /> class.
        /// </summary>
        /// <param name="isSecure">Whether the helper request should be secure</param>
        public SimpleWorkerRequestHelper(bool isSecure, string domain = "", string extention = "/", string locale = "")
            : base(extention, AppDomain.CurrentDomain.BaseDirectory, string.Empty, string.Empty, new StringWriter())
        {
            _domain = domain;
            _locale = locale;
        }
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public override String GetRemoteAddress()
        {
            if (string.IsNullOrEmpty(this._domain))
            {
                return base.GetRemoteAddress();
            }
            else
            {
                return this._domain;
            }
        }
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public override String GetLocalAddress()
        {
            if (string.IsNullOrEmpty(this._domain))
            {
                return base.GetLocalAddress();
            }
            else
            {
                return this._domain;
            }
        }
        /// <summary>
        /// Overriding "GetKnownRequestHeader" in order to force "SimpleWorkerRequest" to return the fake value for locale needed for unit testing.
        /// </summary>
        /// <param name="index">Index associated with HeaderAcceptLanguage in lower level library</param>
        /// <returns>The language or the value from base dll</returns>
        public override string GetKnownRequestHeader(int index)
        {
            if (index == HttpWorkerRequest.HeaderAcceptLanguage && !string.IsNullOrEmpty(_locale))
            {
                return _locale;
            }
            else
            {
                return base.GetKnownRequestHeader(index);
            }
        }
    }
