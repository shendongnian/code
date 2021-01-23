    public string RenderControlToHtml(Control ControlToRender)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
                System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
                ControlToRender.RenderControl(htmlWriter);
                return sb.ToString();
            }
            
            var message = "<p>this is my {0} text</p>";
            
            var ctrl1 = new UserControl1();
            
            PageContent.InnerHtml = String.Format(message,RenderControlToHtml(ctrl1));
