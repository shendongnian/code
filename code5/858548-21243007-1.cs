    foreach (XElement item in xdoc.Elements("Recipe").Elements("Ingredients").Elements("Ingredient"))
    {
        Details content = new Details();
        // initialize other values 
        content.IngredientName = item.Element("Name").Value;
        content.IngredientQuantity = item.Element("Quantity").Value;
        content.IngredientUnit = item.Element("Unit").Value;
        contentList.Add(content);
    }
