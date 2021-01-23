    public class MyHttpClient : HttpClient
    {        
        public MyHttpClient(HttpClientHandler handler) : base(handler) {
            DefaultRequestHeaders = new MyHttpRequestHeaders();
        }
        //
        // Summary:
        //     Gets or Sets the headers which should be sent with each request.
        //
        // Returns:
        //     Returns The headers which should
        //     be sent with each request.
        public new MyHttpRequestHeaders DefaultRequestHeaders { get; set; }
    }
    public class MyHttpRequestHeaders : HttpHeaders
    {
        public MyHttpRequestHeaders()
        {
            HttpClient client = new HttpClient();
            this.Accept = client.DefaultRequestHeaders.Accept;
            this.AcceptCharset = client.DefaultRequestHeaders.AcceptCharset;
            this.AcceptLanguage = client.DefaultRequestHeaders.AcceptLanguage;
            this.Authorization = client.DefaultRequestHeaders.Authorization;
            this.Connection = client.DefaultRequestHeaders.Connection;
            this.ConnectionClose = client.DefaultRequestHeaders.ConnectionClose;
            this.Date = client.DefaultRequestHeaders.Date;
            this.Expect = client.DefaultRequestHeaders.Expect;
            this.ExpectContinue = client.DefaultRequestHeaders.ExpectContinue;
            this.From = client.DefaultRequestHeaders.From;
            this.Host = client.DefaultRequestHeaders.Host;
            this.IfMatch = client.DefaultRequestHeaders.IfMatch;
            this.IfModifiedSince = client.DefaultRequestHeaders.IfModifiedSince;
            this.IfNoneMatch = client.DefaultRequestHeaders.IfNoneMatch;
            this.IfRange = client.DefaultRequestHeaders.IfRange;
            this.IfUnmodifiedSince = client.DefaultRequestHeaders.IfUnmodifiedSince;
            this.MaxForwards = client.DefaultRequestHeaders.MaxForwards;
            this.Pragma = client.DefaultRequestHeaders.Pragma;
            this.ProxyAuthorization = client.DefaultRequestHeaders.ProxyAuthorization;
            this.Range = client.DefaultRequestHeaders.Range;
            this.Referrer = client.DefaultRequestHeaders.Referrer;
            this.TE = client.DefaultRequestHeaders.TE;
            this.Trailer = client.DefaultRequestHeaders.Trailer;
            this.TransferEncoding = client.DefaultRequestHeaders.TransferEncoding;
            this.TransferEncodingChunked = client.DefaultRequestHeaders.TransferEncodingChunked;
            this.Upgrade = client.DefaultRequestHeaders.Upgrade;
            this.UserAgent = client.DefaultRequestHeaders.UserAgent;
            this.Via = client.DefaultRequestHeaders.Via;
            this.Warning = client.DefaultRequestHeaders.Warning;
        }
        // Summary:
        //     Gets the value of the Accept header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Accept header for an HTTP request.
        public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept { get; set; }
        //
        // Summary:
        //     Gets the value of the Accept-Charset header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Accept-Charset header for an HTTP request.
        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset { get; set; }
        //
        // Summary:
        //     Gets the value of the Accept-Language header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Accept-Language header for an HTTP request.
        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Authorization header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.AuthenticationHeaderValue.The value of the
        //     Authorization header for an HTTP request.
        public AuthenticationHeaderValue Authorization { get; set; }
        //
        // Summary:
        //     Gets the value of the Connection header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Connection header for an HTTP request.
        public HttpHeaderValueCollection<string> Connection { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates if the Connection header for an HTTP
        //     request contains Close.
        //
        // Returns:
        //     Returns System.Boolean.true if the Connection header contains Close, otherwise
        //     false.
        public bool? ConnectionClose { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Date header for an HTTP request.
        //
        // Returns:
        //     Returns System.DateTimeOffset.The value of the Date header for an HTTP request.
        public DateTimeOffset? Date { get; set; }
        //
        // Summary:
        //     Gets the value of the Expect header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Expect header for an HTTP request.
        public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates if the Expect header for an HTTP request
        //     contains Continue.
        //
        // Returns:
        //     Returns System.Boolean.true if the Expect header contains Continue, otherwise
        //     false.
        public bool? ExpectContinue { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the From header for an HTTP request.
        //
        // Returns:
        //     Returns System.String.The value of the From header for an HTTP request.
        public string From { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Host header for an HTTP request.
        //
        // Returns:
        //     Returns System.String.The value of the Host header for an HTTP request.
        public string Host { get; set; }
        //
        // Summary:
        //     Gets the value of the If-Match header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the If-Match header for an HTTP request.
        public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the If-Modified-Since header for an HTTP request.
        //
        // Returns:
        //     Returns System.DateTimeOffset.The value of the If-Modified-Since header for
        //     an HTTP request.
        public DateTimeOffset? IfModifiedSince { get; set; }
        //
        // Summary:
        //     Gets the value of the If-None-Match header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.Gets the value
        //     of the If-None-Match header for an HTTP request.
        public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the If-Range header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.RangeConditionHeaderValue.The value of the
        //     If-Range header for an HTTP request.
        public RangeConditionHeaderValue IfRange { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the If-Unmodified-Since header for an HTTP request.
        //
        // Returns:
        //     Returns System.DateTimeOffset.The value of the If-Unmodified-Since header
        //     for an HTTP request.
        public DateTimeOffset? IfUnmodifiedSince { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Max-Forwards header for an HTTP request.
        //
        // Returns:
        //     Returns System.Int32.The value of the Max-Forwards header for an HTTP request.
        public int? MaxForwards { get; set; }
        //
        // Summary:
        //     Gets the value of the Pragma header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Pragma header for an HTTP request.
        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Proxy-Authorization header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.AuthenticationHeaderValue.The value of the
        //     Proxy-Authorization header for an HTTP request.
        public AuthenticationHeaderValue ProxyAuthorization { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Range header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.RangeHeaderValue.The value of the Range header
        //     for an HTTP request.
        public RangeHeaderValue Range { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Referer header for an HTTP request.
        //
        // Returns:
        //     Returns System.Uri.The value of the Referer header for an HTTP request.
        public Uri Referrer { get; set; }
        //
        // Summary:
        //     Gets the value of the TE header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the TE header for an HTTP request.
        public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE { get; set; }
        //
        // Summary:
        //     Gets the value of the Trailer header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Trailer header for an HTTP request.
        public HttpHeaderValueCollection<string> Trailer { get; set; }
        //
        // Summary:
        //     Gets the value of the Transfer-Encoding header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Transfer-Encoding header for an HTTP request.
        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates if the Transfer-Encoding header for an
        //     HTTP request contains chunked.
        //
        // Returns:
        //     Returns System.Boolean.true if the Transfer-Encoding header contains chunked,
        //     otherwise false.
        public bool? TransferEncodingChunked { get; set; }
        //
        // Summary:
        //     Gets the value of the Upgrade header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Upgrade header for an HTTP request.
        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; set; }
        //
        // Summary:
        //     Gets the value of the User-Agent header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the User-Agent header for an HTTP request.
        public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent { get; set; }
        //
        // Summary:
        //     Gets the value of the Via header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Via header for an HTTP request.
        public HttpHeaderValueCollection<ViaHeaderValue> Via { get; set; }
        //
        // Summary:
        //     Gets the value of the Warning header for an HTTP request.
        //
        // Returns:
        //     Returns System.Net.Http.Headers.HttpHeaderValueCollection<T>.The value of
        //     the Warning header for an HTTP request.
        public HttpHeaderValueCollection<WarningHeaderValue> Warning { get; set; }
    }
