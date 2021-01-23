    public class PersonViewModel
    {
        private string _socialSecurityNumber;
        [SocialSecurityNumberLuhn(ErrorMessage = "Incorrect social security number")]
        public string SocialSecurityNumber
        {
            get { return _socialSecurityNumber; }
            set
            {
                _socialSecurityNumber = CleanSocialSecurityNumber(value);
            }
        }
    }
