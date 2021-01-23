        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            if (application != null)
            {
                if (application.Request.Url.ToString().Contains("WebResource.axd"))
                {
                    #region Set private value of HttpWriter so we can write to output stream
                    //See http://daniel-richardson.blogspot.com/2008/11/how-to-apply-filter-to-content-returned.html
                    var response = application.Context.Response;
                    var httpWriterField = typeof(HttpResponse).GetField("_httpWriter",
                                         BindingFlags.NonPublic | BindingFlags.Instance);
                    var ignoringFurtherWritesField = typeof(HttpWriter).GetField("_ignoringFurtherWrites",
                                                     BindingFlags.NonPublic | BindingFlags.Instance);
                    var httpWriter = httpWriterField.GetValue(response);
                    ignoringFurtherWritesField.SetValue(httpWriter, false);
                    #endregion
                    //We need to read filter property first or we get exception
                    var f = application.Response.Filter;
                    application.Response.Filter = new ResponseFilter(application.Response.OutputStream);
                }
            }
        }
