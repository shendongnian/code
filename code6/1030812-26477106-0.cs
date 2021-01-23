    @functions
    {
        protected void HandlePostRequest()
        {
            if(IsPost)
            {
                var name = Request[Fields.Name];
                var email = Request[Fields.Email];
                var subject = Request[Fields.Subject];
                var message = Request[Fields.Message];
                if(Validation.IsValid())
                {
                    using (var rep=new ContactLogRepository("usingClassCode"))
                    {
                        rep.Insert(name, email, subject, message);
                    }
                    Response.Redirect("success.cshtml");
                }
            }
        } 
    }
