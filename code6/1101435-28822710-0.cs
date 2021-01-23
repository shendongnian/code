    public class CustomPasswordHasher : IPasswordHasher
    {
    
    	public string HashPassword(string password)
    	{
    		return password; //return password as is
    	}
    
    	public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
    	{
    		if (hashedPassword.Equals(providedPassword)) {
    			return PasswordVerificationResult.Success;
    		}
    		return PasswordVerificationResult.Failed;
    	}
    }
