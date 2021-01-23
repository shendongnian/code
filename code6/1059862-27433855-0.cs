    @Html.Raw(RenderJavascriptHashArray("InfoURLs", "InfoURLs"))
    @{
                string RenderJavascriptHashArray (string listName, string hashName)
                {
                     
                  IEnumerable<KeyValuePair<int, string>> pairs = this.ViewData[listName] as IEnumerable<KeyValuePair<int, string>>;
                      System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
                      sb.Append("var " + hashName + " = new Array();\n");
                   foreach (KeyValuePair<int, string> pair in pairs)
                    {
                    sb.Append(hashName + "[" + pair.Key.ToString() + "] = \"" + pair.Value + "\";\n");
                    }
                    return sb.ToString();
                }
    }
