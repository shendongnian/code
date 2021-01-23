    you can use  
         
        string[] array = paragraph.Split(" "); 
         
          var allEmails = array.Where(s=>s.Contains("@"));
 
       and then validating using  the following method 
 
 
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
