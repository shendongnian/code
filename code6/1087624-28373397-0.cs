                var formBuilder = new StringBuilder();
            formBuilder.AppendLine("<html><head>");
            formBuilder.AppendLineFormat("</head><body onload=\"document.{0}.submit()\">", formName);
            formBuilder.AppendLineFormat("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", formName, Method.ToString(), Url);
            for (int i = 0; i < _inputValues.Keys.Count; i++) {
                formBuilder.AppendLineFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", 
                    HttpUtility.HtmlEncode(_inputValues.Keys[i]), HttpUtility.HtmlEncode(_inputValues[_inputValues.Keys[i]]));
            }
            formBuilder.AppendLine("</form>");
            formBuilder.AppendLine("</body></html>");
          
            _httpContext.Response.Clear();
            _httpContext.Response.Write(formBuilder.ToString());
            _httpContext.Response.End();
