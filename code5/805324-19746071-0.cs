    public class PasswordRuleAttribute : ValidationAttribute
        {    
            public override bool IsValid(object value)
            {
    
                if (new RequiredAttribute { ErrorMessage = "Password cannot be blank." }.IsValid(value) && new StringLengthAttribute(20) { MinimumLength=3 }.IsValid(value) )
                    return true;
    
                return false;
            }
        }
