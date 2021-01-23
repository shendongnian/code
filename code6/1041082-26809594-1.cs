    public class RegisterService<TUserAuth> : Service
    {
        public IValidator<Register> RegistrationValidator { get; set; }
        //...
    }
