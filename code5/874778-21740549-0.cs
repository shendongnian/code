    app.UseCookieAuthentication(new CookieAuthenticationOptions() 
    { 
       TicketDataFormat = new MyCustomSecureDataFormat()
    });
    public class MyCustomSecureDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
         private static AuthenticationTicket savedTicket;
    
         public string Protect(AuthenticationTicket ticket)
         {
             //Ticket value serialized here will be the cookie sent. Encryption stage.
             //Make any changes if you wish to the ticket
             ticket.Identity.AddClaim(new Claim("Myprotectionmethod", "true"));
             return MySerializeAndEncryptedStringMethod(ticket);
         }
    
         public AuthenticationTicket Unprotect(string cookieValue)
         {
             //Invoked everytime when a cookie string is being converted to a AuthenticationTicket. 
             return MyDecryptAndDeserializeStringMethod(cookieValue);
         }
     }
