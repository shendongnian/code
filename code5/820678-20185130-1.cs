    protected void Page_Load(object sender, EventArgs e)
    {
        //Note: Nothing Here... 
        //Use this event for setting the page up
    }
    //Use this event for handling the click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //MAKE SURE YOU USE ERROR HANDLING FOR THE REAL WORLD
        string Answer = string.Empty;
        Answer = "Email Sent3";
        StringBuilder builder = new StringBuilder();
        //NOTE: You should be sanitising client input
        string Name = txtName.Text;
        string Link = txtLink.Text;
        string Why = txtWhy.Text;
        //String builder is a better way to build a string
        //or look at string.Format();            
        builder.Append("<div dir='ltr'>");
        builder.AppendLine("<h4>You got a new video idea from </h4>");
        builder.AppendLine(Name);
        builder.AppendLine("<br />");
        builder.AppendLine("Link: ");
        builder.Append(Link);
        builder.AppendLine("<br />");
        builder.AppendLine("Reason: ");
        builder.Append(Why);
        builder.AppendLine("</div>");
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("MY EMAIL", "MY PASS"),
            EnableSsl = true
        };
        System.Net.Mail.MailMessage mail1 = new System.Net.Mail.MailMessage();
        mail1.Body = builder.ToString(); //Get the body
        mail1.From = new System.Net.Mail.MailAddress("MY EMAIL");
        mail1.IsBodyHtml = true;
        mail1.Subject = "Vidoe Idea By " + Name;
        mail1.To.Add("MY EMAI");
        client.Send(mail1);
        Answer = "Email Sent";
        //Display a message so the user knows it worked!
        pnlSucess.Visible = true;
    }
