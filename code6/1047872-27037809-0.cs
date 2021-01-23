    SmtpClient client=new SmtpClient( );
            client.Credentials = new NetworkCredential("username", "password");
            MailMessage msg = new MailMessage();
            client.Host = "yourHost";
            msg.From =new MailAddress( "adress-from");
            msg.To.Add( new MailAddress("adress-to"  ));
            msg.Subject = "your subject";
            msg.Body="your message";
            System.Net.WebRequest myrequest;
            System.Net.WebResponse myresponse;
            System.IO.Stream s;
            string url = "your url to the file";
            myrequest = System.Net.WebRequest.Create(url);
            myresponse = myrequest.GetResponse();
            s = myresponse.GetResponseStream();
            msg.Attachments.Add(new Attachment( s,System.Net.Mime.MediaTypeNames.Text.Plain));
            
            client.Send(msg);
