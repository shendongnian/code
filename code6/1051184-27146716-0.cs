    public string[] GenerateProxyAssembly()
    {
      //create a WebRequest object and fetch the WSDL file for the web service
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.uri);
      request.Credentials = CredentialCache.DefaultCredentials;
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      System.IO.Stream stream = response.GetResponseStream();
 
      //read the downloaded WSDL file
      ServiceDescription desc = ServiceDescription.Read(stream);
 
      //find out the number of operations exposed by the web service
      //store the name of the operations inside the string array
      //iterating only through the first binding exposed as
      //the rest of the bindings will have the same number
      int i = 0;
      Binding binding = desc.Bindings[0];
      OperationBindingCollection opColl = binding.Operations;
      foreach (OperationBinding operation in opColl)
      {
        listOfOperations[i++] = operation.Name;
      }
 
      //initializing a ServiceDescriptionImporter object
      ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
 
      //set the protocol to SOAP 1.1
      importer.ProtocolName = "Soap12";
 
      //setting the Style to Client in order to generate client proxy code
      importer.Style = ServiceDescriptionImportStyle.Client;
 
      //adding the ServiceDescription to the Importer object
      importer.AddServiceDescription(desc, null, null);
      importer.CodeGenerationOptions = CodeGenerationOptions.GenerateNewAsync;
 
      //Initialize the CODE DOM tree in which we will import the 
      //ServiceDescriptionImporter
      CodeNamespace nm = new CodeNamespace();
      CodeCompileUnit unit = new CodeCompileUnit();
      unit.Namespaces.Add(nm);
 
      //generating the client proxy code
      ServiceDescriptionImportWarnings warnings = importer.Import(nm, unit);
 
      if (warnings == 0)
      {
        //set the CodeDOMProvider to C# to generate the code in C#
        System.IO.StringWriter sw = new System.IO.StringWriter();
        CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
        provider.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());
 
        //creating TempFileCollection
        //the path of the temp folder is hardcoded
        TempFileCollection coll = new TempFileCollection(@"C:\wmpub\tempFiles");
        coll.KeepFiles = false;
               
        //setting the CompilerParameters for the temporary assembly
        string[] refAssembly = { "System.dll", "System.Data.dll", 
          "System.Web.Services.dll", "System.Xml.dll" };
        CompilerParameters param = new CompilerParameters(refAssembly);
        param.GenerateInMemory = true;
        param.TreatWarningsAsErrors = false;
        param.OutputAssembly = "WebServiceReflector.dll";
        param.TempFiles = coll;
        //compile the generated code into an assembly
        //CompilerResults results = provider.CompileAssemblyFromDom(param, unitArr);
        CompilerResults results 
           = provider.CompileAssemblyFromSource(param, sw.ToString());
        this.assem = results.CompiledAssembly;
      }
 
      //return the list of operations exposed by the web service
      return listOfOperations;
    }
