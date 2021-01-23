    var schemas = new XmlSchemaSet();
    schemas.Add(null, schema); // schema can be a string or a path.
    bool hasErrors = false;
    document.Validate(schemas, (o, e) =>
    {
    	Console.WriteLine("{0}", e.Message);
    	hasErrors = true;
    });
