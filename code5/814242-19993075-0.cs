    Type attributeType = typeof(AssemblyFileVersionAttribute);
    
    // To identify the constructor, use an array of types representing 
    // the constructor's parameter types. This ctor takes a string. 
    //
    Type[] ctorParameters = { typeof(string) };
    
    // Get the constructor for the attribute. 
    //
    ConstructorInfo ctor = attributeType.GetConstructor(ctorParameters);
    
    // Pass the constructor and an array of arguments (in this case, 
    // an array containing a single string) to the  
    // CustomAttributeBuilder constructor. 
    // 
    object[] ctorArgs = { "1.0.4.0" };     
    CustomAttributeBuilder attribute =
       new CustomAttributeBuilder(ctor, ctorArgs);
    
    // Finally, apply the attribute to the assembly. 
    //
    assemblyBuilder.SetCustomAttribute(attribute);
    assemblyBuilder.DefineVersionInfoResource();
    
    // Finally, save the assembly
    assemblyBuilder.Save(name.Name + ".dll");
