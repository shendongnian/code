    public partial class DetailsViewModel
    {
        public Nullable<int> ContryCode { get; set; }
        public string PhoneNumber{ get; set; }
        public string PhoneNumberWithContryCode 
        {
             get
             {
                 return string.Format("+{0} {1}", ContryCode, PhoneNumber);
             }
             set
             {
                  // Code to parse the string to ContryCode and PhoneNumber
             }
    }
