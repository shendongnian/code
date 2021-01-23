    var method2 = typeof(Program).GetMethod("MyMethodX", BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    var body = method2.GetMethodBody();
    Type[] compilerGeneratedVariables = body.LocalVariables.Select(x => x.LocalType).Where(x => x.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Length != 0).ToArray();
    byte[] ilInstructions = body.GetILAsByteArray(); // You can hash these
    if (compilerGeneratedVariables.Length != 0)
    {
        // There are some local variables of types that are compiler generated
        // This is a good sign that the compiler has changed the code
    }
