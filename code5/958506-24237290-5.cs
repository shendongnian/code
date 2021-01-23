        public class CookieMaker
        {
        public CookieMaker()
        {
         
        }
        public HttpCookie CreateCookie(bool remembered, string user, string role)
        {
            DateTime dtExpire;
            bool persistent = false;
            if (remembered)
            {
                dtExpire = DateTime.Now.AddDays(14);
                persistent = true;
            }
            else
            {
                dtExpire = DateTime.Now.AddMinutes(30);
            }
            FormsAuthenticationTicket frmTicket =
                new FormsAuthenticationTicket(1,
                                            user,
                                            DateTime.Now,
                                            dtExpire,
                                            persistent,
                                            role,
                                            FormsAuthentication.FormsCookiePath);
            //encrypt the created ticket.
            string encryptTicket = FormsAuthentication.Encrypt(frmTicket);
            //create a new cookie using encripted ticket
            HttpCookie cookie = new HttpCookie(
                       FormsAuthentication.FormsCookieName, encryptTicket);
            //set date for cookie expiration if check-box has checked.
            if (frmTicket.IsPersistent)
                cookie.Expires = frmTicket.Expiration;
            return cookie;
        }
     }
