    protected override void OnInit(EventArgs e)
            {
                string userAgent = Request.UserAgent;
                if (userAgent.Contains("BlackBerry")
                  || (userAgent.Contains("iPhone") || (userAgent.Contains("Android"))))
                {
                    //add css ref to header from code behind
                    HtmlLink css = new HtmlLink();
                    css.Href = ResolveClientUrl("~/mobile.css");
                    css.Attributes["rel"] = "stylesheet";
                    css.Attributes["type"] = "text/css";
                    css.Attributes["media"] = "all";
                    Page.Header.Controls.Add(css);
                }
            }
