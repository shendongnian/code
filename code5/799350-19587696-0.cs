    public ActionResult AddProduct(MyModel model)
    {
    var Result = context.Product.Where(s => s.ProductName.ToUpper() ==  model.NewProductName.ToUpper()).FirstOrDefault();
    return view();
    }
