    DemoService dsc = new DemoService(new Uri("http://services.odata.org/V4/OData/(S(ut2byeiaglm424a0pbovpo33))/OData.svc/"));
    var product = dsc.Products.Expand("Categories").Where(p => p.ID == 1).Single();
    
    foreach (var c in product.Categories)
    {
        dsc.DeleteLink(product, "Categories", c);
    }
    dsc.SaveChanges(SaveChangesOptions.BatchWithSingleChangeset);
