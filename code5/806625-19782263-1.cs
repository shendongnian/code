    class UIHintAttribute : ValidationAttribute
    {
            public string Field {get;set;}
            UIHint(string field)
            {
                    Field = field;
            }
            public override bool IsValid(object value)
            {
    
                if(Field == "DisplayName")
                {
                if (new RequiredAttribute { ErrorMessage = "DisplayName cannot be blank." }.IsValid(value) && new StringLengthAttribute(50).IsValid(value) )
                    return true;
    
                return false;
                }
                if(Field == "EmailAddress")
                {
                if (new RequiredAttribute { ErrorMessage = "Email address cannot be blank." }.IsValid(value) && RegularExpressionAttribute("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}$"){
              ErrorMessage = "The email address you specified is invalid."}.IsValid(value) && new StringLengthAttribute(100).IsValid(value))
                    return true;
    
                return false;
                }
                // Needs to return true by default unless Required exists
                return true;
            }
    }
