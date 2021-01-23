    using Portable.Licensing.Validation;
    var validationFailures = license.Validate()  
                                .ExpirationDate()  
                                    .When(lic => lic.Type == LicenseType.Trial)  
                                .And()  
                                .Signature(publicKey)  
                                .AssertValidLicense();
