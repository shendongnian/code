    internal void TestStatusPassed(string str_TestID)
    {
         var testId = Oid.FromToken(str_TestID, _context.MetaModel);
         var query = new Query(testId);
         var testType = _context.MetaModel.GetAssetType("Test");
         var sourceAttribute = testType.GetAttributeDefinition("Status");
         query.Selection.Add(sourceAttribute);
         var result = _context.Services.Retrieve(query);
         var test = result.Assets[0];
         var oldSource = GetValue(test.GetAttribute(sourceAttribute).Value);
         test.SetAttributeValue(sourceAttribute, "TestStatus:9123");
         _context.Services.Save(test);
     }
 
