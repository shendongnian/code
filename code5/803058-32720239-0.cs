      public class SimplePasswordHasher : IPasswordHasher
      {
         public string HashPassword(string password)
         {
            return Crypto.HashPassword(password);
         }
         public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
         {
            if(Crypto.VerifyHashedPassword(hashedPassword, providedPassword))
            return PasswordVerificationResult.Success;
            else return PasswordVerificationResult.Failed;
          }  
      }
