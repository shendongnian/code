    var jObject = JObject.Parse(\* your json *\);
    var recordFile = new RecordFile
               {
                   Page = jObject.Value<string>("page"),
                   Context = jObject.Value<string>("context"),
                   Records = new Records
                             {
                                 RCount = jObject["records"].Value<int>("rCount"),
                                 RecordsDictionary =
                                     jObject["records"].Children<JProperty>()
                                                       .Where(prop => prop.Name != "rCount")
                                                       .ToDictionary(prop => prop.Name),
                                                                     prop =>
                                                                     prop.Value.ToObject<List<Record>>())
                             }
               };
