    var options = new ProxyGenerationOptions();
    options.AddMixinInstance(new TypePresenter<SampleViewModel>());
    
    var pg = new ProxyGenerator();
    var sample = pg.CreateClassProxy<SampleViewModel>(options);
    //var sampleType = sample.GetType();
    
    var typeDescriptor = (ICustomTypeDescriptor)sample;
    
    // Error doesn't happen anymore on this line.
    var properties = typeDescriptor.GetProperties();
