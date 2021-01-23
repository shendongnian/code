    Console.WriteLine(typeof (Tuple<,>).FullName); //For information only, outputs "System.Tuple`2"
    var typeName = "System.Tuple`2";
    var type = Type.GetType(typeName);
    var generic = type.MakeGenericType(typeof (string), typeof (int));
    Console.WriteLine(generic.FullName); //Outputs the type with the type parameters.
