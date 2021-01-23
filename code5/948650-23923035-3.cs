    protected string ColumnDetail() {
        string html = String.Empty;
        foreach (string x in Enum.GetNames(typeof(ImportColumns))) {
            html = (html + string.Format("<td>{0}</td>", Eval(x)));
        }
        return html;
    }
 
