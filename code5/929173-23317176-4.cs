    private static readonly SyntaxTemplate _pointerIndirectionTemplate 
          = new SyntaxTemplate("p.Value");
    private static readonly SyntaxTemplate _propertyReferenceTemplate
         = new SyntaxTemplate("System.Property.Bind(__v_pr__ => o = __v_pr__, () => o)");
    private static readonly SyntaxTemplate _propertyReferenceTypeTemplate 
         = new SyntaxTemplate("System.IProperty<T>");
    private static readonly SyntaxTemplate _enumerableTypeTemplate 
         = new SyntaxTemplate("System.Collections.Generic.IEnumerable<T>");
