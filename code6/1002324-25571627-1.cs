    @foreach (ContentCategoryModel cat in catList.OfType<ContentCategoryModel>())
    {
        <li>
            @cat.CategoryName
        </li>
    }
    @foreach (ProdCategoryModel cat in catList.OfType<ProdCategoryModel>())
    {
        <li>
            @cat.CategoryName
        </li>
    }
    @foreach (NewsCategoryModel cat in catList.OfType<NewsCategoryModel>())
    {
        <li>
            @cat.CategoryName
        </li>
    }
