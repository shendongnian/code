    public class CommentModel 
    {
        public string Subject { get; set; }
        
        [AllowHtml]
        public string Text { get; set; }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult AddComment(CommentModel model) ...
