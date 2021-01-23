    [CustomAction]
    public static ActionResult ReadXml(Session session)
    {
      var doc = XDocument.Load("data.xml");
      var settings = from setting in doc.Descendants("setting")
                     select new
                     {
                       Name = setting.Attribute("name").Value,
                       Value = setting.Attribute("value").Value
                     };
      foreach (var setting in settings)
      {
        session.Log(string.Format("{0} = {1}", setting.Name, setting.Value));
      }
      return ActionResult.Success;
    }
