    void Do(IDataContext dataContext)
    {
      foreach (var reference in dataContext.GetData(DataConstants.REFERENCES))
      {
        var resolveResultWithInfo = reference.Resolve().Result;
        var typeElement = resolveResultWithInfo.DeclaredElement as ITypeElement;
        if (typeElement != null)
        {
          var substitution = resolveResultWithInfo.Substitution;
          var declaredType = TypeFactory.CreateType(typeElement, substitution);
        }
      }
    }
