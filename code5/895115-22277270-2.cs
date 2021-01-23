    public IHtmlString customHtml(string htmlCode){
        var sb = new StringBuilder();
        for(int i = 1; i<=4; i++){
            sb.AppendFormat(htmlCode, i);
        }
        return new HtmlString(sb.ToString());
     }
