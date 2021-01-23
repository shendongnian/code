    var link = new HyperLink
    {
        Text = item.Product.Name,
        NavigateUrl = item.Product.Url.ToString(),
        CssClass = "prodNameLink"
    };
    var panel = new Panel
    {
        CssClass = "productname"
    };
    panel.Controls.Add(link);
    tcProduct.Controls.Add(panel);
