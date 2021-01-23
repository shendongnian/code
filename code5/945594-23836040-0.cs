    new JArray(
            (from e in db.HostedVoiceAAKeys
            where e.HostedVoiceAAID == aaid.HostedVoiceAAID)
                .ToList()
                .Select(h => new JObject(
                        new JProperty("id",e.OptionKey),
                        new JProperty("text",e.OptionGuid)))
                .ToArray()
         )
