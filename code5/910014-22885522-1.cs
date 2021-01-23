    public class MyMailer : MailerBase, IMyMailer 	
    {
        public virtual MvcMailMessage MyAction(string foo, string bar)
        {
            ViewBag.Foo = foo;
            ViewBag.Bar = bar;
            // Populate ...
        }
    }
