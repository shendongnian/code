    public class UsernameValidator : UserNamePasswordValidator
    {
        private const string UserName = "your_username_here";
        private const string Password = "your_password_here";
    
        public override void Validate(string userName, string password)
        {
            // validate arguments
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
    
            //
            // Nombre de usuario y contraseñas hardcodeados por seguridad
            //
            if (!userName.Equals(UserName) || !password.Equals(Password))
                throw new SecurityTokenException("Nombre de usuario o contraseña no válidos para consumir este servicio");
        }
    }
