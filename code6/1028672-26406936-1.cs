    protected override void OnPreRender(EventArgs e)
    {     
        var ctrl = new HtmlGenericControl("div");
        string html = this.GetArticleText();
        
        // create the html formatted HTML/Links taking into account anti-xss attacks
        foreach(var tag in this.LoadAllTags())
        {
          html.Replace(tag.Key, this.CreateLinkHtml(tag);
        }
        
        ctrl.InnerHtml = html;
        
        this.SomePageContainer.Controls.Add(ctrl);
    
        base.OnPreRender(e);
    }
