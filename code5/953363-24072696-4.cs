    public static List<User_Content> GetContentByType(string ContentType, string language)
    {
      return (from ac in db.User_Contents
              where c.Type == (ContentType == "All" ? c.Type : ContentType)
              where c.Languages == (language == "All" ? c.Languages : language)
              where ac.isApproved.ToString().Contains(char.Parse("t").ToString())
              select ac).ToList();
    }
