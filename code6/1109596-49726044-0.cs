    var options = ScriptOptions.Default
        .AddReferences(
            typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).GetTypeInfo().Assembly,
            typeof(System.Runtime.CompilerServices.DynamicAttribute).GetTypeInfo().Assembly);
    
    var globals = new DynamicData();
    globals.Data.Name = "John";
    globals.Data.MiddleName = "James";
    globals.Data.Surname = "Jamison";
    
    var text = "My name is {Data.Name} {Data.MiddleName} {Data.Surname}";
    var result = await CSharpScript.EvaluateAsync<string>($"$\"{text}\"", options, globals);
