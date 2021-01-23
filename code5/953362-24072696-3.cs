    public static ArrayList GetContentByType(string ContentType, string language)
    {
      var allcontent = from ac in db.User_Contents
                       where c.Type == (ContentType == "All" ? c.Type : ContentType)
                       where c.Languages == (language == "All" ? c.Languages : language)
                       where ac.isApproved.ToString().Contains(char.Parse("t").ToString())
                       select ac;
      ArrayList result = new ArrayList(allcontent);
      return result;
    }
