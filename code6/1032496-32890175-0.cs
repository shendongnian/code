    using System.IdentityModel.Selectors;
    
    namespace MyProject
    {
        public class CustomUserNameValidator : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
                if (username != "Bob" && password != "Letmein")
                    through new SecurityTokenException("If you're name's not Bob, you're not coming in!")
            }
        }
    }
