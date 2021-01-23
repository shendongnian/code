    using System.Net;
    using System.Net.Mail;
    
    using UnityEngine;
    
    public class SendMail : MonoBehaviour {
    	public string sender = "me@mymailaccount.com";
    	public string receiver = "me@mymailaccount.com";
    	public string smtpPassword = "mysmtppassword";
    	public string smtpHost = "mail.mymailacount.com";
    
    	// Use this for initialization
    	private void Start() {
    		using (var mail = new MailMessage {
    			From = new MailAddress(sender),
    			Subject = "test subject",
    			Body = "Hello there!"
    		}) {
    			mail.To.Add(receiver);
    
    			var smtpServer = new SmtpClient(smtpHost) {
    				Port = 25,
    				Credentials = (ICredentialsByHost)new NetworkCredential(sender, smtpPassword)
    			};
    			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    			smtpServer.Send(mail);
    		}
    	}
    }
