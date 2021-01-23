    public class User
    {
        private string PasswordHash {get; set;} //assuming your db supports serializing private properties. If not increase visibility as necessary.
    
        public void SetPassword(string newPassword)
        {
            PasswordHash = PasswordHasher.CreateHash(newPassword);
        }
    
        public bool VerifyPassword(string passwordCandidate)
        {
            return PasswordHasher.Verify(PasswordHash, passwordCandidate);
        }
    }
