    [Test]
    public void SimplestLabel()
    {
       var className = "SimplestLabelClass";
       var dataAnnotation = "[DisplayName(\"Your Username: \")]";
       var formattedClass = string.Format(unformattedClass,
         className,
         dataAnnotation);
       var model = CreateDynamicModel(formattedClass, className);
       var html = HtmlHelperFactory.Create(model);
    }
    private object CreateDynamicModel(string formattedClass, string className)
    {    
      object result;
      using (var csharp = new Microsoft.CSharp.CSharpCodeProvider())
      {
        var res = csharp.CompileAssemblyFromSource(
            new System.CodeDom.Compiler.CompilerParameters() 
            {  
                GenerateInMemory = true 
            }, 
            formattedClass
        );
        var classType = res.CompiledAssembly.GetType(className);
        result = Activator.CreateInstance(type);
      }
      return result;
    }       
