    var link = new HyperLink();
    var img = new HtmlGenericControl("img");
    img.Attributes.Add("src", "text.png");
    link.Controls.Add(new Literal{ Text = "Test"});    // this line will add the text
    link.Controls.Add(img);
