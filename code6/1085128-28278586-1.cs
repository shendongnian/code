    public void Save (Customer c, ProductList products)
    {
        // Validate that you have entered at least one product.
        if (!ProductList.IsValid)
        {
            ReturnErrorSummary(ProductList.ValidationResult);
        }
    }
