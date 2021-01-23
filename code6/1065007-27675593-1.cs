    foreach (var attribute in node.AttributeLists.SelectMany(al => al.Attributes))
    {
        if (csFile.FileSemanticModel.GetTypeInfo(attribute).Type.ToDisplayString() == "Proj.Attributes.ValidationAttribute")
        {
            var arg = attribute.ArgumentList.Arguments.FirstOrDefault(aa => aa.NameEquals.Name.Identifier.Text == "IsJDate");
            if (arg != null && arg.Expression.IsKind(SyntaxKind.TrueLiteralExpression))
                validationKind = ValidationKind.JDate;
        }
    }
