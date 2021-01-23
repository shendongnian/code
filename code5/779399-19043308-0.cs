    view 
    <% using(Html.BeginForm("Sendlink", "Home")) %>
        <% { %>
         <input type="text" id="toemail" value="" />
            <input type="submit" value="Send" />
        <% } %>
    Controller
    public ActionResult Sendlink()
    {
        return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Sendlink(FormCollection formCollection)
    {
        try
        {
            string message = Session["link"].ToString();
            string toemail = formCollection["toemail"];
            MailEngine.Send("mail@mail.com", toemail, "link", message);
            return RedirectToAction("CanvasShare");
        }
        catch
        {
    
        }
        return null;
    }
    
    Code (Model)
    
    
    	
    
    I am trying to send an email inside an action. However, the action always returns a blank screen.
    
    View:
    
    <% using(Html.BeginForm("Sendlink", "Home")) %>
        <% { %>
         <input type="text" id="toemail" value="" />
            <input type="submit" value="Send" />
        <% } %>
    
    Controller:
    
    public ActionResult Sendlink()
    {
        return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Sendlink(FormCollection formCollection)
    {
        try
        {
            string message = Session["link"].ToString();
            string toemail = formCollection["toemail"];
            MailEngine.Send("mail@mail.com", toemail, "link", message);
            return RedirectToAction("CanvasShare");
        }
        catch
        {
    
        }
        return null;
    }
    
    Class MailEngine:
    
    public static void Send(string from, string to, string subject, string body)
    {
        try
        {
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.mymail.com");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.Send(mail);
        }
        catch
        {
    
        }
    }`enter code here`
