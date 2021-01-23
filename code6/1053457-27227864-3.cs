        // this bypass the double check : attempts to set the value if Valid.
        // otherwise, either returns a validation result,
        // either throws an exception.
        public registrationValidation_Enum validate_registration(
            string newRegistration,
            bool canThrowException)
        {
            bool isValid = test_registration(newRegistration);
            if (isValid == registrationValidation_Enum.Valid)
            {
                registration = newRegistration;
                return registrationValidation_Enum.Valid;
            }
            else
            {
                if (canThrowException)
                {
                    string exceptionMessage = "";
                    if (isValid | registrationValidation_Enum.TooLong)
                    {
                        exceptionMessage += "Registration too long" 
                                         + Environment.NewLine;
                    }
                    if (isValid | registrationValidation_Enum.InvalidChars)
                    {
                        exceptionMessage += 
                            "Registration contains invalid characters"
                            + Environment.NewLine;
                    }
                    // ....
                    Throw New Exception(exceptionMessage);
                }
                else
                {
                    return isValid;
                }
            }
        }
