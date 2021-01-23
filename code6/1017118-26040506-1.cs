    protected override IDictionary<Type, Action<object>> InitializationMap
    {
       get
       {
          return new MyInitalizationDictionary
          {
             (INewSchoolWizardExtension o) => o.InitializeWizard(this),
             (INewSchoolWizardExtension o) => o.Start()
          };
       }
    }
