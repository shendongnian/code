    typeof(TypedModel).GetProperties();
    TypedModel typeModel = new TypedModel {number = 1, text = "text1", 
    ListOhterModel = new List()
    };
    foreach(var prop in typeModel.GetType().GetProperties()) 
    {
        Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(typeModel, null));
    }
