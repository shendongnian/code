    IEnumerable<ICSharpCode.NRefactory.CSharp.Attribute> GetAttributes(TypeDeclaration typeDeclaration)
    {
        return typeDeclaration.Members
            .SelectMany(member => member
                .Attributes
                .SelectMany(attr => attr.Attributes));
    }
