    public class AjaxController : Controller
    {
        public ActionResult Email()
        {
            MailMessage message = new MailMessage("from@fake.com","marketing@fake.com");
    
            foreach (string form_inputs in Request.Form.Keys)
            {
                String  input_name  =   form_inputs.ToString();
                String  input_value =   Request.Form[form_inputs].Trim();
                if(input_name == "File")
                {            
                    HttpPostedFileBase file = Request.Files[input_name];
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(file.InputStream, file.FileName); //ERROR
                    message.Attachments.Add(attachment);
                }
                if (input_name == "Name")
                {
                    message.Body = "Name: " + input_value;
                }
            }
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "SMTP.fake.com";
    
            client.Send(message);
        }
    }
