    public class EmailController : Controller
    {
        public ActionResult Email() 
        {
            var viewModel = new EmailViewModel();
            // Pass an empty view model to your view
            return View(viewModel);
        }
        // This controller action will be hit when you submit your form
        // and the default MVC model binder will create your viewModel with
        // the appropriate values submitted from your form.
        [HttpPost]
        public ActionResult Email(EmailViewModel viewModel)
        {
            // Make sure the data coming server-side is valid
            // You can use validation attributes like [Required] in your View Model
            if(ModelState.IsValid)
            {
                try 
                {
                    WebMail.SmtpServer = "localhost";
                    WebMail.SmtpPort = 25;
                    WebMail.EnableSsl = false;
                    WebMail.UserName = "user@localhost";
                    WebMail.Password = "smtppassword";
                    WebMail.From = "user@localhost";;
                    WebMail.Send(
                        "test@localhost", 
                        viewModel.RequestorName, // RequestorName entered from form
                        viewModel.RequestorDate.ToString() // RequestorDate entered from form
                    );
                }
                catch (Exception ex ) 
                {
                    errorMessage = ex.Message;
                }
            }
            return View(viewModel);
        }
    }
    
