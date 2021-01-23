    Initialize();
    var object = CreateObject();  // calls ObjectUsageMap.IncrementCountFor(object);
    DestroyObject(object);        // calls ObjectUsageMap.DecrementCountFor(object);
    // calls ObjectUsageMap.DecrementCountFor(object) inside next line
    DestroyFurtherObjectsWithReferenceToMyObject(); 
    GC.Collect();
    Assert.AreEqual(0, ObjectUsageMap.GetCountFor(object));
