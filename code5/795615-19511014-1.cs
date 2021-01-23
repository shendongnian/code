    // prepare our property overriding type descriptor
    PropertyOverridingTypeDescriptor ctd = new PropertyOverridingTypeDescriptor(TypeDescriptor.GetProvider(selectedObject).GetTypeDescriptor(selectedObject));
    // iterate through properies in the supplied object/type
    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(selectedObject))
    {
      // for every property that complies to our criteria
      if (pd.Name.EndsWith("x") || pd.Name.EndsWith("y"))
      {
        // we first construct the custom PropertyDescriptor with the TypeDescriptor's
        // built-in capabilities
        PropertyDescriptor pd2 =
            TypeDescriptor.CreateProperty(
                selectedObject.GetType(), // or just _settings, if it's already a type
                pd, // base property descriptor to which we want to add attributes
          // The PropertyDescriptor which we'll get will just wrap that
          // base one returning attributes we need.
                new CategoryAttribute("Location")
          // this method really can take as many attributes as you like,
          // not just one
            );
        // and then we tell our new PropertyOverridingTypeDescriptor to override that property
        ctd.OverrideProperty(pd2);
      }
    }
    // then we add new descriptor provider that will return our descriptor istead of default
    TypeDescriptor.AddProvider(new TypeDescriptorOverridingProvider(ctd), selectedObject);
