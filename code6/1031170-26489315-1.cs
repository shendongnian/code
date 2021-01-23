    public class CustomUserNameValidator : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
    	        if (username!="test" && password!="test")
    	        {
    		    throw new FaultException("Unknown username or incorrect password.");
    	        }
                return;
            }
        }
