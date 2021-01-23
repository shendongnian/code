     HtmlGenericControl Link5 = new HtmlGenericControl();
     Link5.TagName = "script";
     Link5.Attributes.Add("href", ResolveClientUrl("~/MyApp/Greybox/gb_styles.css"));
     Link5.Attributes.Add("rel", "stylesheet");
     Link5.Attributes.Add("type", "text/javascript");
     Page.Header.Controls.Add(Link5);
