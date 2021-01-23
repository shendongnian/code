    var file = XElement.Load(path);
    var submitInfos = file.Elements("submitInfo")
                          .Select(submitInfo =>
                                  {
                                      Settings = submitInfo.Elements("setting")
                                                           .Select(setting =>
                                                                   {
                                                                       name = setting.Attribute("name").Value,
                                                                       info = setting.Attribute("info").Value,
                                                                       path = setting.Attribute("path").Value,
                                                                       serializeAs = setting.Attribute("serializeAs").Value,
                                                                       values = setting.Elements("add")
                                                                                       .ToDictionary(c => c.Attribute("name").Value, c => c.Attribute("value").Value)
                                                                   })
                                  });
