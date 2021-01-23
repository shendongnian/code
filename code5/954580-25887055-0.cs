     public  PartialViewResult _CommentForm(int? sessionId)
        {
            Console.WriteLine(sessionId.ToString());
            Comment comment = new Comment() { SessionId = sessionId??0 };
            return PartialView("_CommentForm", comment);
        }
