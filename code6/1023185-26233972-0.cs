    string GetInnerHtml()
        {
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(sw))
                {
                    Page.RenderControl(htmlWriter);
                    return sw.ToString();
                }
            }
        }
