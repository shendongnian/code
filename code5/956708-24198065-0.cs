    public void BindDocumentTypes(params Type[] types)
    {
        Debug.Assert
            (types.All(p => typeof (IWeinCadDocument).IsAssignableFrom(p)));
         foreach (var documentType in types)
        {
            Kernel.Bind<IWeinCadDocument>()
                  .To(documentType)
                  .Named(documentType.GUID.ToString());
        }
    }
    
