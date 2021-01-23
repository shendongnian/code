        var _cat = new Categories();
        _cat.GetCategories();
        p.ProductCategory = p.ProductCategory + "0";
        var prodCat = p.ProductCategory.Split(',').Select(int.Parse).ToArray();
        lblSaveCat.Text = string.Join("\r\n", _cat.Where(x => prodCat.Contains(x.Id)).Select(c => c.CatName));
