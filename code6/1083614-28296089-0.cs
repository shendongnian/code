    var creationDate = DateTime.Now;
    var expirationDate = creationDate.AddSeconds(5);
    var ticket = new FormsAuthenticationTicket(1, "ticket", creationDate,
        expirationDate, false, "userData");
    var cookie = new Cookie("cookie",
        FormsAuthentication.Encrypt(ticket));
    cookie.Expires = expirationDate;
    Console.WriteLine("Cookie value: {0}", cookie.Value);
    Console.WriteLine("Ticket has expired? {0}", ticket.Expired.ToString());
    Console.WriteLine("Ticket userData: {0}", ticket.UserData);
    System.Threading.Thread.Sleep(6000);
    Console.WriteLine("Cookie and ticket should have expired");
    Console.WriteLine("Cookie value: {0}", cookie.Value);
    var decryptedTicket = FormsAuthentication.Decrypt(cookie.Value);
    Console.WriteLine("Ticket has expired? {0}", decryptedTicket.Expired.ToString());
    Console.WriteLine("Ticket userData: {0}", decryptedTicket.UserData);
