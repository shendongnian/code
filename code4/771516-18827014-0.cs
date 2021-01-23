    public SampleProcessResult Process()
    {
        if (eligiblityValidationClass != Guid.Empty)
        {
            Type validatorType = Type.GetTypeFromCLSID(eligiblityValidationClass);
            IEligibilityValidation validator;
            try
            {
                validator = Activator.CreateInstance(validatorType) as IEligibilityValidation;
            }
            catch (COMException)
            {
                // The class doesn't exist, or instance failed to be created
                // for some other reason.
            }
            if (validator == null)
            {
                // The class exists, but it doesn't implement the interface.
            }
            bool isValid = validator.IsValid();
        }
    }
