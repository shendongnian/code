    HtmlLink subcss = new HtmlLink();
            subcss.Href = name of css file as sting;
            subcss.Attributes.Add("rel", "stylesheet");
            subcss.Attributes.Add("type", "text/css");
            Page.Header.Controls.Add(subcss);
