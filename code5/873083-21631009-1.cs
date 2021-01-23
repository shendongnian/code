    public class CustomValidator
    {
        public static void EmailValidator(object source, ServerValidateEventArgs args)
        {
            string strInput = args.Value.Trim();
            CustomValidation v = new CustomValidation();
            args.IsValid = v.ValidateEmail(strInput);
        }
    }
    <asp:CustomValidator OnClick="CustomValidator.EmailValidator" />
