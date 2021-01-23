    public void SendRegistrationConfirmation(string toAddress, string confirmUrl)
    {
       const string subject = "Your Registration";
       
       //load the template
       var template = File.OpenText(AssemblyDirectory + " \\Templates\\NewProgramRegistration.Template").ReadToEnd();
   
       //replace content in the template
       //We have this #URL# string in the places we want to actually put the URL
       var emailContent = template.Replace("#URL#", confirmUrl);
       //Just a helper that actually sends the email, configures the server, etc
       this.SendEmail(toAddress, subject, emailContent);
    }
