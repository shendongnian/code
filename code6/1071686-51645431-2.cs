    TestModel testModel = new TestModel();
    testModel.Id = 1;
    testModel.Name = "ItemName";
    
    // When we add this to session an entry will be written to DynamoDB Asp.NetSessionTable
    Session["Checkout"] = testModel;
