    public List<Brand> GetFilteredList(MySearchCriteria filters)
    {
        var brands = myDataContext.Brands; //All brands (for now)
        if(filters.ProductType_Id > 0)
        {
              //IF the filter has a value, filter the list accordingly:
              brands = brands.Where(brand => brand.Products.Any(product => product.TypeId == filters.ProductType_Id);
        }
        if(filters.ProductWeight_LessThan > 0)
        {
              //IF the filter has a value, filter the list accordingly:
              brands = brands.Where(brand => brand.Products.Any(product => product.Weight < filters.ProductWeight_LessThan));
        }
        if(!String.IsNullOrWhiteSpace(filters.ProductName_Contains))
        {
              //IF the filter has a value, filter the list accordingly:
              brands = brands.Where(brand => brand.Products.Any(product => product.Name.Contains(filters.ProductName_Contains)));
        }
         return brands.ToList();
    }
