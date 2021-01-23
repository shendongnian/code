    ...
    <#@ assembly name="$(SolutionDir)../res/ICSharpCode.NRefactory.dll" #>
    <#@ assembly name="$(SolutionDir)../res/ICSharpCode.NRefactory.CSharp.dll" #>
    <#@ import namespace="ICSharpCode.NRefactory.CSharp" #>
    <#@ import namespace="System.CodeDom.Compiler" #>
    ...	
    	
    <#+
    public class XsdSchemaTransformer : CSharpTemplate
    {
        public void TransformSchemas(TransformationContext transformationContext)
        {
            ...
            foreach (string file in files)
            {
                ...
                string transformText = typesTemplate.Transform();
                transformText = ModifyGeneratedCodeAttributeXmlVersionNumber(transformText);
                typesTemplate.Context.Write(typesTemplate.Output, transformText);
            }
        }
    
        private string ModifyGeneratedCodeAttributeXmlVersionNumber(string source)
        {
    	    CSharpParser parser = new CSharpParser();
    	    SyntaxTree syntaxTree = parser.Parse(source);
    	    IEnumerable<TypeDeclaration> typeDeclarations = syntaxTree.Descendants.OfType<TypeDeclaration>();
    	    foreach (TypeDeclaration typeDeclaration in typeDeclarations)
    	    {
    		    AttributeSection generatedCodeAttributeSection = typeDeclaration.Attributes.FirstOrDefault(x => x.Attributes.FirstOrDefault(y => IsTypeOfGeneratedCodeAttribute(y.Type)) != null);
    		    if (generatedCodeAttributeSection != null)
    		    {
    			    ICSharpCode.NRefactory.CSharp.Attribute generatedCodeAttribute = generatedCodeAttributeSection.Attributes.FirstOrDefault(x => IsTypeOfGeneratedCodeAttribute(x.Type));
    			    PrimitiveExpression primitiveExpression = (PrimitiveExpression)generatedCodeAttribute.Arguments.ElementAt(1);
    			    string xmlVersionNumber = Convert.ToString(primitiveExpression.Value);
    			    string[] splittedVersionNumber = xmlVersionNumber.Split('.');
    			    string formatedXmlVersionNumber = string.Format("{0}.{1}", splittedVersionNumber[0], splittedVersionNumber[1]);
    			    generatedCodeAttribute.Arguments.Remove(primitiveExpression);
    			    generatedCodeAttribute.Arguments.Add(new PrimitiveExpression(formatedXmlVersionNumber));
    		    }
    	    }
        
    	    return syntaxTree.GetText();
        }
        
        private bool IsTypeOfGeneratedCodeAttribute(AstType type)
        {
    	    return type.ToString().Equals(typeof(GeneratedCodeAttribute).FullName);
        }
    }
    #>
