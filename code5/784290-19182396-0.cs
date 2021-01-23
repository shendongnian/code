    // Execute
    var actualCategories = (SelectList)result.ViewBag.categoryList;
    // Assert
    Assert.IsNotNull(result); 
    Assert.AreEqual(expectedCategories.Count(), actualCategories.Count());
    for (var i = 0; i < expectedCategories.Count(); i++)
    {
        Assert.AreEqual(expectedCategories.ElementAt(i).Value, actualCategories.ElementAt(i).Value);
        Assert.AreEqual(expectedCategories.ElementAt(i).Text, actualCategories.ElementAt(i).Text);
    }
