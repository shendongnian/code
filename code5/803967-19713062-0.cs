    // Bootstrap the block at startup using default configuration file
    ValidationFactory.SetDefaultConfigurationValidatorFactory(
        new SystemConfigurationSource());
    
    AThing bob = new AThing();
    bob.Name = null;
    
    ValidationResults vr = Validation.Validate(bob, "default");
    Debug.Assert(!vr.IsValid); 
