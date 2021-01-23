    // method is the MethodInfo reference
    // member is CodeMemberMethod (CodeDom) used to generate the output method; 
    foreach (CustomAttributeData attributeData in method.GetCustomAttributesData())
    {
        var arguments = new List<CodeAttributeArgument>();
        foreach (var argument in attributeData.ConstructorArguments)
        {
            arguments.Add(new CodeAttributeArgument(new CodeSnippetExpression(argument.ToString())));
        }
    
        if (attributeData.NamedArguments != null)
            foreach (var argument in attributeData.NamedArguments)
            {
                arguments.Add(new CodeAttributeArgument(new CodeSnippetExpression(argument.ToString())));
            }
    
        member.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(attributeData.AttributeType), arguments.ToArray()));
    }
