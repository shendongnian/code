    public ViewModelService() 
    { 
        var categoryRepository = CategoryRepositoryServiceLocator.Instance;
        var passwordRepository = PasswordRepositoryServiceLocator.Instance;   
        var modelValidator  FModelValidatorServiceLocator.Instance;
        ...
    }
