        static void Main(string[] args)
        {
            var restriction = new XmlSchemaSimpleTypeRestriction { BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema") };
            restriction.Facets.Add(new XmlSchemaMinLengthFacet { Value = "3" });
            Console.WriteLine(Validate(restriction, "str"));
        }
