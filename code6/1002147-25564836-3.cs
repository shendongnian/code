    public partial class RemotePost
    {
        /// <summary>
        /// Gets or sets the remote URL to POST to.
        /// </summary>
        public string PostUrl
        { get; set; }
    
        /// <summary>
        /// Gets or sets the form's HTML name.
        /// </summary>
        public string FormName
        { get; set; }
    
        /// <summary>
        /// Gets the collection of POST data.
        /// </summary>
        public NameValueCollection PostData
        { get; private set; }
    
    
        /// <param name="postUrl">The remote URL to POST to.</param>
        public RemotePost(string postUrl)
        {
            this.PostData = new NameValueCollection();
            this.PostUrl = postUrl;
            this.FormName = "formName";
        }
    
        /// <summary>
        /// Adds the specified name and value to the POST data collection..
        /// </summary>
        /// <param name="name">The name of the element to add</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(string name, string value)
        {
            this.PostData.Add(name, value);
        }
    
        public void Post()
        {
            var context = HttpContext.Current;
            context.Response.Clear();
            context.Response.Write("<html><head>");
            context.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", this.FormName));
            context.Response.Write(string.Format("<form name=\"{0}\" method=\"post\" action=\"{1}\" >", this.FormName, this.PostUrl));
    
            foreach(string name in this.PostData)
            {
                context.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", HttpUtility.HtmlEncode(name), HttpUtility.HtmlEncode(this.PostData[name])));
            }
    
            context.Response.Write("</form>");
            context.Response.Write("</body></html>");
            context.Response.End();
        }
    }
