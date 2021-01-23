        partial void SSN_Validate(EntityValidationResultsBuilder results)
        {
            if (this.SSN != null)
            {
                if (this.SSN.Length == 9 && !this.SSN.Contains("-"))
                {
                    this.SSN = this.SSN.Substring(0, 3) + "-" + this.SSN.Substring(3, 2) + "-" + this.SSN.Substring(5);
                }
                if(!Regex.IsMatch(this.SSN, @"^\d{3}-\d{2}-\d{4}$"))
                {
                    results.AddPropertyError("Please enter a valid SSN (i.e. 123-45-6789).");
                }
            }            
        }
