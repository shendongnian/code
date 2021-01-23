    static IValidationInfo Validate(ILicense someLic)
    {
        // Implementation
    }
    interface IValidationInfo
    {
        IEnumerable<LicenseErrorCodes> KnownErrors { get; }
        IEnumerable<string> WierdErrors { get; }
    }
