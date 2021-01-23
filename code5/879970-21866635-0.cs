    var TestId = Oid.FromToken("Test:26017", _context.MetaModel);
    var TestAsset = _context.MetaModel.GetAssetType("Test");
    var newTestAsset = _context.Services.New(TestAsset, TestId);
    var TestStatusAttr = newTestAsset.GetAttributeDefinition("Status.Name");
    newTestAsset.SetAttributeValue(TestStatusAttr, "Failed");
    _context.Services.Save(newTestAsset);
