    public void Parse()
    {
        try
        {
            XmlTextReader reader2 = new XmlTextReader(@"stack-problem2.xsd");
            XmlSchema myschema2 = XmlSchema.Read(reader2, ValidationCallback);
            var simpleAnotation = new XmlSchemaAnnotation();
            simpleAnotation.Id = "Lost Anotation";
            // <xs:complexType name="ESS3754">
            XmlSchemaComplexType complexType = new XmlSchemaComplexType();
            myschema2.Items.Add(complexType);
            complexType.Name = "ESS3754";
            // <xs:choice minOccurs="1" maxOccurs="1">
            XmlSchemaChoice choice = new XmlSchemaChoice();
            complexType.Particle = choice;
            choice.MinOccurs = 1;
            choice.MaxOccurs = 1;
            XmlSchemaElement elementSelected = new XmlSchemaElement();
            choice.Items.Add(elementSelected);
            elementSelected.Name = "String1";
            
            AnnonateMyComplexType(choice); 
            
            FileStream file = new FileStream(@"satck-solution.xsd", FileMode.Create, FileAccess.ReadWrite);
            XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding());
            xwriter.Formatting = Formatting.Indented;
            myschema2.Write(xwriter);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static void AnnonateMyComplexType(XmlSchemaChoice xmlSchemaComplexType)
    {
        XmlSchemaAnnotation myCustomAnnotation = new XmlSchemaAnnotation();
        xmlSchemaComplexType.Annotation = myCustomAnnotation;
        // <xs:documentation>State Name</xs:documentation>
        XmlSchemaDocumentation schemaDocumentation = new XmlSchemaDocumentation();
        myCustomAnnotation.Items.Add(schemaDocumentation);
        schemaDocumentation.Markup = TextToNodeArray("Headline_VVVVV");
        // <xs:appInfo>Application Information</xs:appInfo>
        XmlSchemaAppInfo appInfo = new XmlSchemaAppInfo();
        myCustomAnnotation.Items.Add(appInfo);
        appInfo.Markup = TextToNodeArray("Headline_VVVVV");
    }
    static void ValidationCallback(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("ERROR: ");
        Console.WriteLine(args.Message);
    }
