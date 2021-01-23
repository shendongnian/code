    var authCookie = FormsAuthentication.GetAuthCookie(userName, rememberUser.Checked);
    // Get the FormsAuthenticationTicket out of the encrypted cookie
    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
    // Create a new FormsAuthenticationTicket that includes our custom User Data
    var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "userData");
    // Update the authCookie's Value to use the encrypted version of newTicket
    authCookie.Value = FormsAuthentication.Encrypt(newTicket);
