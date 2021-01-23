    public static string ProductName
    {
     get
     {
        AssemblyProductAttribute myProduct =(AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
         typeof(AssemblyProductAttribute));
          return myProduct.Product;
      }
    }
