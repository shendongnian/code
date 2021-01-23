    var link = new HyperLink();
    var img = new HtmlGenericControl("img");
    var lbl = new Label();
    img.Attributes.Add("src", "text.png");
    lbl.Text = "Test";
    link.Controls.Add(img);
    link.Controls.Add(lbl);
    this.Controls.Add(link);
