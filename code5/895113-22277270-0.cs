    public IHtmlString customHtml(string htmlCode){
        var sb = new StringBuilder();
        for(int i = 0; i<4 i++){
            sb.AppendFormat(htmlCode, i);
        }
        return new HtmlString(sb.ToString());
     }
