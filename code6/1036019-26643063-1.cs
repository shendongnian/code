    JObject originalObject = JObject.Parse(json);
    var analogInputTrueValues = originalObject.Descendants()
                                              .OfType<JProperty>()
                                              .Where(p => p.Name == "AnalogInput")
                                              .Select(x => x.Value.ToString())
                                              .ToArray();
