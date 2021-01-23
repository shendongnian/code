    List<String> theComments = Fetcher.getImageComments(commentsConnectionString, imagePath, 2);
    List<String> theUser = Fetcher.getImageComments(commentsConnectionString, imagePath, 0);
    List<String> theDate = Fetcher.getImageComments(commentsConnectionString, imagePath, 3);
   
    string template = lstTemplate.InnerHtml;
    StringBuilder innerItems = new StringBuilder();
    if (theComments.Count >= 0)
    {
       for (var i = 0; i < theComments.Count; i++)
       {
          innerItems.AppendFormat(template, theUser[i], theComment[i], theDate[i]);
       }
       lstComments.InnerHtml = innerItems.ToString();
    }
   
