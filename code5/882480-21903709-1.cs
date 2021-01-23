    [Validator(typeof(NewModelValidator))]
    class NewModel
    {
        //...Model implementation omitted
    }
    
    public class NewModelValidator : AbstractValidator<NewModel>
    {
        public NewModelValidator()
        {
            
            RuleFor(x => x.Email).Must(IsUnieuqEmail).WithMessage("Email already exists");
        }
    
        private bool IsUniqueEmail(string mail)
        {
            var _db = new DataContext();
            if (_db.NewModel.SingleOrDefault(x => x.Email == mail) == null) return true;
            return false;
        }
    }
