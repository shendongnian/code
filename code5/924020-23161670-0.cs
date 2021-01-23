    //find method with testcategory attribute
    if (attrs.Any(x => x is TestCategoryAttribute))
    {
        var testCategoryAttrs = attrs.Where(x => x is TestCategoryAttribute);
        if (testCategoryAttrs.Any())
        {
            foreach (var testCategoryAttr in testCategoryAttrs)
            {
                TestCategoryAttribute attr = (TestCategoryAttribute)testCategoryAttr;
                testCategories += string.IsNullOrEmpty(testCategories)
                    ? string.Join(", ", attr.TestCategories)
                    : string.Format(", {0}", string.Join(", ", attr.TestCategories));
            }
        }                               
    }
