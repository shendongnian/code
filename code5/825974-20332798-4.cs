        private bool IsEmailValid(string mail)
        {
            try             {                
                    MailAddress eMailAddress = new MailAddress(mail);
                    return true;
             
                return false;  
            }
            catch (FormatException)
            {
               
                return false;  
            }
        }
