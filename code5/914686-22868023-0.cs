    public virtual MvcMailMessage Welcome()
    {
        var message = Populate(x => {
            x.ViewName = "Welcome";
            x.To.Add("some-email@example.com");
            x.Subject = "Welcome";
        });
        message.Body = PreMailer.Net.PreMailer.MoveCssInline(message.Body).Html;
        return message;
    }
