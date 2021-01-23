    public static class ClientScript
    {
        public static void InsertScript(string script, Control target)
        {
            HtmlGenericControl s = new HtmlGenericControl();
            s.TagName = "script";
            s.InnerHtml = script;
            target.Controls.Add(s); 
        }        
    }
