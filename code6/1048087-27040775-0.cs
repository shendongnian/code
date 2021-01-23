    public ActionResult Index(int? id, string title = null)
    {
        if (String.IsNullOrWhiteSpace(title))
        {
             var product = // load product
             return Redirect(Url.Action("Index", "Product",
                                        new { id = id, title = product.Title }));
        }
        // your code
    }
