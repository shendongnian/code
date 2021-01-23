    public MvcHtmlString GetComments(long pictureID)
    {
        DBContext db = new DBContext();
        Picture picture = new Picture();
        //PictureComment comments = new PictureComment();
        var comments = from c in db.PictureComments
                       where pictureID == c.PictureID
                       orderby c.DateTime descending
                       select c;
        StringBuilder sb = new StringBuilder();
        foreach (var comment in comments)
        {
            sb.AppendLine(picture.GetUsername(comment.UserID));
            sb.AppendLine(comment.Comment);
        }
        return new MvcHtmlString(sb.ToString());
    }
