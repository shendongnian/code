    var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
    {
        { "Field1", "String Value 1" },
        { "Field2", "String Value 2" },
        { "Field3", "String Value 3" }
    });
    // Call create controller with test data
    _controller.Create(formCol);
