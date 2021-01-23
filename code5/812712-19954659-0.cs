    protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            
            writer.AddAttribute("onclick", "YourFunction()")
            base.AddAttributesToRender(writer);
        }
