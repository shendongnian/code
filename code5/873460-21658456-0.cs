    protected override void CreateChildControls()
    {
    	HtmlGenericControl div1 = new HtmlGenericControl("div");
    	div1.Attributes.Add("class", "modalbox");
    	if (!ClientVisible)
    		div1.Attributes.CssStyle.Add("display", "none");
    	HtmlGenericControl div2 = new HtmlGenericControl("div");
    	div2.Attributes.Add("class", "modalbox-m1");
    	HtmlGenericControl div3 = new HtmlGenericControl("div");
    	div3.Attributes.Add("class", "modalbox-m2");
    	div1.Controls.Add(div2);
    	div2.Controls.Add(div3);
    	while (Controls.Count != 0)
    		div3.Controls.Add(Controls[0]);
    	Controls.Add(div1);
    }
