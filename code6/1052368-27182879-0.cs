    public class MailSenderAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //your code...
        }
    }
    ...
    [MailSenderAttribute]
    public ActionResult YourAction() { /*code*/ }
