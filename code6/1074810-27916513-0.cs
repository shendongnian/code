    if (product == null)
    ;//no duplicates
    
    if (product.Code == entity.Code)
    {
      error.Add('Duplicate code');
    }
    
    if (product.Name == entity.Name)
    {
      error.Add('Duplicate name');
    }
    
    if (product.OtherField == entity.OtherField)
    {
      error.Add('Duplicate other field');
    }
