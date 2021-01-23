      protected string GetErrors()
        {
            string Errors = "";
            bool isValidTest = false;
            Validate("myValidationGroup");
            isValidTest = IsValid;
            if (!isValidTest)
            {
                foreach (BaseValidator ctrl in this.Validators)
                {
                    if (!ctrl.IsValid && ctrl.ValidationGroup == "myValidationGroup")
                    {
                        Errors += ctrl.ErrorMessage + "\n";
                    }
                }
            }
            return Errors.Trim();
        }
