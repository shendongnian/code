    @functions {
        public static bool IsValidEmail(string value) {
            try{
                MailAddress email = new MailAddress(value);
                return true;
            }
            catch(FormatException fex){
                return false;
            }
        }
    }
