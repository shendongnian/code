    protected void Page_PreRender(object sender, EventArgs e)
            {
                if (HttpContext.Current.Request.QueryString["FirstRun"] == "1")
                {
                    NameValueCollection nvc = HttpUtility.ParseQueryString(Request.Url.Query);
                    nvc.Remove("FirstRun");
                    string url = Request.Url.AbsolutePath;
                    for (int i = 0; i < nvc.Count; i++)
                        url += string.Format("{0}{1}={2}", (i == 0 ? "?" : "&"), nvc.Keys[i], nvc[i]);
                    Response.Redirect(string.Format("{1}&NoCache={0}",System.Guid.NewGuid().ToString().Replace("-",""),url));
                }
            }
