        public registrationValidation_Enum test_registration(
            string newRegistration)
        {
            registrationValidation_Enum checkResult =
                registrationValidation_Enum.Valid;
    
            // Do the checks here
            if (newRegistration.Length > 10)
            {
                checkResult = checkResult | registrationValidation_Enum.TooLong;
            }
            if (containsNonAlphNumericChars(newRegistration))
            {
                checkResult = checkResult | registrationValidation_Enum.InvalidChars;
            }
            // ...
            return checkResult;
        }
