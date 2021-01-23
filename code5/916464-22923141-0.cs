    JObject obj = JObject.Parse(json);
    if (obj != null)
    {
        var root = obj.First;
        if (root != null)
        {
            var sumJson = root.First;
            if (sumJson != null)
            {
                var sum = sumJson.ToObject<Sum>();
            }
        }
    }
