            if (HttpContext.Current.Request.Form.Count > 0)
            {
                sb.Append("<html>");
                sb.AppendFormat("<body onload='document.forms[0].submit()'>Loading...");
                sb.AppendFormat("<form action='{0}' method='post'>",your_url);
                foreach (string key in HttpContext.Current.Request.Form.AllKeys)
                {
                    sb.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", key,
                        HttpContext.Current.Request.Form[key]);
                }
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
    
    
            }
